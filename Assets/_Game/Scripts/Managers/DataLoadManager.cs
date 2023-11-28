using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine.Core
{
    public class DataLoadManager : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_InputField _input;

        public void LoadData()
        {
			CloudSaveManager.LoadSomeData();
		}

        public void SaveData()
        {
			CloudSaveManager.SaveSomeData(_input.text);
		}
	}
}