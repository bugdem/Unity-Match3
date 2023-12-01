using ClocknestGames.Library.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.Core
{
    public class LevelEditor : MonoBehaviour
    {
        [Header("Limitation")]
        [SerializeField] private TMPro.TextMeshProUGUI _limitationTypeText;
        [SerializeField] private TMPro.TextMeshProUGUI _limitationText;

        [Header("Target")]
        [SerializeField] private Transform _targetContainer;
        [SerializeField] private LevelTargetView _targetViewPrefab;



        public LevelData CurrentData { get; private set; }
        private Dictionary<string, LevelTargetView> _targetViews = new();

        public void LoadData(LevelData data)
        {
            CurrentData = data;

            Redraw();
        }

        private void Redraw()
        {
            // Limitation (Move count or time)
            if (CurrentData.Limitation == LevelLimitationType.Move)
            {
                _limitationTypeText.SetText("Move");
                _limitationText.SetText(CurrentData.MoveCount.ToString());
            }
            else if (CurrentData.Limitation == LevelLimitationType.Time)
            {
				TimeSpan time = TimeSpan.FromSeconds(CurrentData.TimeCounter);
				string timeLimitation = time.ToString(@"mm\:ss");

				_limitationTypeText.SetText("Time");
				_limitationText.SetText(timeLimitation);
			}
            else
            {
                throw new System.Exception("Limitation Type is not implemented!");
            }

            // Targets to complete level
            _targetContainer.gameObject.RemoveAllChild();
            _targetViews.Clear();
			foreach (var target in CurrentData.Targets)
            {
                var targetView = Instantiate(_targetViewPrefab, _targetContainer);
                targetView.SetData(target);
                _targetViews.Add(target.ElementId, targetView);
			}
        }
    }
}