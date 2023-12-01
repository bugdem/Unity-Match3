using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine.Core
{
    public class LevelTargetView : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _countText;
        [SerializeField] private Image _image;

        public LevelTarget Target { get; private set; }

        public void SetData(LevelTarget target)
        {
            Target = target;

			_countText.SetText(Target.Count.ToString());
		}

        public void SetCount(ushort count)
        {
            Target.Count = count;

			_countText.SetText(Target.Count.ToString());
		}
    }
}