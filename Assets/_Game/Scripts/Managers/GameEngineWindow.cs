using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEngine.Editor 
{ 
	public class GameEngineWindow : EditorWindow //OdinMenuEditorWindow
	{
		/*
		[MenuItem("My Game/My Editor")]
		private static void OpenWindow()
		{
			GetWindow<GameEngineWindow>().Show();
		}

		protected override void OnImGUI()
		{
			// Show main title
			EditorGUILayout.LabelField("Match 3 Editor", new GUIStyle
			{
				fontSize = 25,
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.MiddleCenter,
				normal = new GUIStyleState()
				{
					textColor = Color.white
				}
			}
			, GUILayout.Height(50));

			base.OnImGUI();


		}

		protected override OdinMenuTree BuildMenuTree()
		{
			var tree = new OdinMenuTree();
			tree.Selection.SupportsMultiSelect = false;

			tree.Add("Level Editor", new LevelEditor());
			tree.Add("Items/Piece Settings", new ItemPieceSettings());
			tree.Add("Items/Piece Test", new ItemPieceSettings());
			
			return tree;
		}

		protected override void OnBeginDrawEditors()
		{
			base.OnBeginDrawEditors();

			var selectedTreeMenuItem = this.MenuTree.Selection;
			if (selectedTreeMenuItem != null)
			{
				var panel = selectedTreeMenuItem.SelectedValue as BaseEditorPanel;
				if (panel != null)
					panel.OnBeginDrawEditors(selectedTreeMenuItem[0]);
			}
		}

		protected override void OnEndDrawEditors()
		{
			base.OnEndDrawEditors();

			var selectedTreeMenuItem = this.MenuTree.Selection;
			if (selectedTreeMenuItem != null)
			{
				var panel = selectedTreeMenuItem.SelectedValue as BaseEditorPanel;
				if (panel != null)
					panel.OnEndDrawEditors(selectedTreeMenuItem[0]);
			}
		}
		*/
	}

	#region Panels
	[System.Serializable]
	public class BaseEditorPanel
	{
		public virtual void OnBeginDrawEditors(OdinMenuItem menuItem) { }
		public virtual void OnEndDrawEditors(OdinMenuItem menuItem) { }
	}

	[System.Serializable]
	public class LevelEditor : BaseEditorPanel
	{
		public string Test;

		public override void OnBeginDrawEditors(OdinMenuItem menuItem)
		{
			base.OnBeginDrawEditors(menuItem);

			EditorGUILayout.LabelField("Arigato : " + menuItem.Name);
		}

		public override void OnEndDrawEditors(OdinMenuItem menuItem)
		{
			base.OnEndDrawEditors(menuItem);

			EditorGUILayout.LabelField("LEYLEY : " + menuItem.Name);
		}
	}

	[System.Serializable]
	public class ItemPieceSettings : BaseEditorPanel
	{

	}

	[System.Serializable]
	public class ItemPieceSettingsTest : BaseEditorPanel
	{

	}
	#endregion

}