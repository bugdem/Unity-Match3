using ClocknestGames.Game.Core;
using ClocknestGames.Library.Utils;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEngine.Core
{
    public class LevelGrid : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private Vector2Int _size = new Vector2Int(9, 15);
		[SerializeField] private Vector2 _cellSize = new Vector2(1f, 1f);
		[SerializeField] private Vector2 _cellSpacing = new Vector2(0.1f, 0.1f);

        [Header("References")]
		[SerializeField] private Transform _cellContainer;
        [SerializeField] private LevelGridCell _cellPrefab;


        private Dictionary<Vector2Int, LevelGridCell> _cells = new();

		private void Awake()
		{
            Draw();
		}

        [Button("Draw Grid")]
		private void Draw()
        {
            Clear();


            Vector3 cellStartPosition = new Vector3(-(_size.y - 1) * (_cellSize.x + _cellSpacing.x) * .5f, -(_size.x - 1) * (_cellSize.y + _cellSpacing.y) * .5f, 0f);

			for (int x = 0; x < _size.x; x++)
            {
                for (int y = 0; y < _size.y; y++)
                {
                    Vector2Int cellIndex = new Vector2Int(x, y);
                    var newCell = CGExec.RunInMode<LevelGridCell>(() => Instantiate(_cellPrefab, _cellContainer)
                                                                , () => PrefabUtility.InstantiatePrefab(_cellPrefab, _cellContainer) as LevelGridCell);
                    newCell.gameObject.name = $"Cell-{cellIndex.x},{cellIndex.y}";
                    Vector3 cellLocalPosition = new Vector3(y * (_cellSize.x + _cellSpacing.x), x * (_cellSize.y + _cellSpacing.y), 0f);
                    newCell.transform.localPosition = cellLocalPosition + cellStartPosition;
                    newCell.transform.localScale = new Vector3(_cellSize.x, _cellSize.y, 1f);
                    newCell.CellIndex = cellIndex;

                    _cells.Add(cellIndex, newCell);
                }
            }
        }

		[Button("Clear Grid")]
		private void Clear()
        {
            CGExec.RunInMode(() => _cellContainer.gameObject.RemoveAllChild(), () => _cellContainer.gameObject.RemoveAllChild(true));
			_cells.Clear();
		}
    }
}