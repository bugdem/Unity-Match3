using ClocknestGames.Library.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.Core
{
    public class LevelEditor : Singleton<LevelEditor>
    {
        [Header("Level")]
        [SerializeField] private TMPro.TextMeshProUGUI _levelNameText;

        [Header("Limitation")]
        [SerializeField] private TMPro.TextMeshProUGUI _limitationTypeText;
        [SerializeField] private TMPro.TextMeshProUGUI _limitationText;

        [Header("Target")]
        [SerializeField] private Transform _targetContainer;
        [SerializeField] private LevelTargetView _targetViewPrefab;

        public LevelData CurrentData { get; private set; }
        public bool IsNewLevel { get; private set; }
        private Dictionary<string, LevelTargetView> _targetViews = new();

        public void LoadData(LevelData data, bool isNewLevel)
        {
            CurrentData = data;
            IsNewLevel = IsNewLevel;

            Redraw();
        }

        private void Redraw()
        {
            DrawTitle();
            DrawLimitation();
            DrawTargets();
        }

        public void DrawTitle()
        {
			string levelName = IsNewLevel ? "New Level" : CurrentData.Name;
			_levelNameText.SetText($"{levelName} - Level #{CurrentData.Index}");
		}

        public void DrawLimitation()
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
		}

        public void DrawTargets()
        {
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