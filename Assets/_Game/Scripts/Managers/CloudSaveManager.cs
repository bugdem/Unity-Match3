using ClocknestGames.Library.Utils;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;
using UnityEngine;

namespace GameEngine.Core
{
	[Serializable]
	public enum CloudSaveInitializeEventType
	{
		None = 0,
		Initializing,
		Ready,
		Failed
	}

	public struct CloudSaveInitializeEvent
	{
		CloudSaveInitializeEventType EventType;

		public CloudSaveInitializeEvent(CloudSaveInitializeEventType eventType)
		{
			EventType = eventType;
		}
	}

    public class CloudSaveManager : MonoBehaviour
    {
		[SerializeField, ReadOnly] private CloudSaveInitializeEventType _eventType = CloudSaveInitializeEventType.None;

		public CloudSaveInitializeEventType EventType
		{
			get => _eventType;
			set => _eventType = value;
		}

		private async void Awake()
		{
			SetInitializeStatus(CloudSaveInitializeEventType.Initializing);
			await UnityServices.InitializeAsync();
			await SignInAnonymouslyAsync();
		}

		private async Task SignInAnonymouslyAsync()
		{
			AuthenticationService.Instance.SignedIn += () =>
			{
				var playerId = AuthenticationService.Instance.PlayerId;
				Debug.Log("Cloud Save Signed in as: " + playerId);

				SetInitializeStatus(CloudSaveInitializeEventType.Ready);
			};
			AuthenticationService.Instance.SignInFailed += s =>
			{
				// Take some action here...
				Debug.Log("Cloud Save Failed!: " + s);

				SetInitializeStatus(CloudSaveInitializeEventType.Failed);
			};

			await AuthenticationService.Instance.SignInAnonymouslyAsync();
		}

		private void SetInitializeStatus(CloudSaveInitializeEventType initializeType)
		{
			EventType = initializeType;
			EventManager.TriggerEvent(new CloudSaveInitializeEvent(EventType));
		}

		public static async void SaveSomeData(string testValue)
		{
			var data = new Dictionary<string, object> { { "key", testValue } };
			await CloudSaveService.Instance.Data.Player.SaveAsync(data);
		}

		public static async void LoadSomeData()
		{
			var savedData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "key" });
			Item test = savedData["key"];
			var result = test.Value.GetAsString();

			Debug.Log("Load Data: " + result);
		}
	}
}