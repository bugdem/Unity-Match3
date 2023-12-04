using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.Core
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Transform _window;

        public bool IsShowing => _window.gameObject.activeSelf;

		private void Awake()
		{
            Hide();
		}

		public void Show()
        {
            _window.gameObject.SetActive(true);

            OnShown();
        }

        public void Hide()
        {
            _window.gameObject.SetActive(false);

            OnHidden();
        }

        protected virtual void OnShown()
        {

        }

        protected virtual void OnHidden()
        {

        }
    }
}