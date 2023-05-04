using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static MyEditor.EditorTemplate;

[CustomEditor(typeof(TextController_Base),true)]
public class TextController_Inspector : Editor
{bool open;
	

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var targ = target as TextController_Base;

		Space(SpaceType.vertical);
		open = Group.OpenableGroup(Direction.vertical, open, "Options", () => {

			// フェード
			targ.fadable = Group.ToggleGroup(targ.fadable, "Fadable", Direction.vertical, () => {
				targ.inDuration = EditorGUILayout.Slider("FadeInDuration", targ.inDuration, 0, 1);              // フェードイン時間
				targ.outDuration = EditorGUILayout.Slider("FadeOutDuration", targ.outDuration, 0, 1);           // フェードアウト時間
				targ.normalDuration = EditorGUILayout.Slider("NormalDuration", targ.normalDuration, 0, 1);      // 通常時間
			});

			// 移動
			targ.movable = Group.ToggleGroup(targ.movable, "Movable", Direction.vertical, () => {
				targ.movingDuration = EditorGUILayout.Slider("MovingDuration", targ.movingDuration, 0, 3);      // 移動時間
				targ.targetPosition = EditorGUILayout.Vector2Field("TargetPosition", targ.targetPosition);      // 目標座標
				targ.movingEaseType = (Ease)EditorGUILayout.EnumPopup("MovingEaseType", targ.movingEaseType);   // イージングの種類
			});

			// 拡大縮小
			targ.scalable = Group.ToggleGroup(targ.scalable, "Scalable", Direction.vertical, () => {
				targ.scalingDuration = EditorGUILayout.Slider("ScalingDuration", targ.scalingDuration, 0, 3);   // スケーリング時間
				targ.targetScale = EditorGUILayout.Vector2Field("TargetScale", targ.targetScale);               // 目標スケール
				targ.scalingEaseType = (Ease)EditorGUILayout.EnumPopup("ScalingEaseType", targ.scalingEaseType);// イージングの種類
			});
		});
	}
}
