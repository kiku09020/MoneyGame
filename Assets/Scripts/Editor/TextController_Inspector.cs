using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static MyEditor.EditorTemplate;

[CustomEditor(typeof(TextControllersParameter),true), CanEditMultipleObjects]
public class TextController_Inspector : Editor
{
	bool delayGroupFlag;


	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();

		var targ = target as TextControllersParameter;

		Space(SpaceType.vertical);

		// 遅延
		targ.delay = EditorGUILayout.FloatField("Delay", targ.delay);

		// 色
		targ.colorable = Group.ToggleGroup(targ.colorable, "Colorable", Direction.vertical, () => {
			targ.targetColor = EditorGUILayout.ColorField("TargetColor", targ.targetColor);
		});

		// フェード
		targ.fadable = Group.ToggleGroup(targ.fadable, "Fadable", Direction.vertical, () => {
			targ.inDuration = EditorGUILayout.Slider("FadeInDuration", targ.inDuration, 0, 1);              // フェードイン時間
			targ.normalDuration = EditorGUILayout.Slider("NormalDuration", targ.normalDuration, 0, 1);      // 通常時間
			targ.outDuration = EditorGUILayout.Slider("FadeOutDuration", targ.outDuration, 0, 1);           // フェードアウト時間
		});

		// 移動
		targ.movable = Group.ToggleGroup(targ.movable, "Movable", Direction.vertical, () => {
			targ.movingDuration = EditorGUILayout.Slider("MovingDuration", targ.movingDuration, 0, 3);      // 移動時間
			targ.startPosition = EditorGUILayout.Vector2Field("StartPosition", targ.startPosition);         // 初期位置
			targ.targetPosition = EditorGUILayout.Vector2Field("TargetPosition", targ.targetPosition);      // 目標座標
			targ.movingEaseType = (Ease)EditorGUILayout.EnumPopup("MovingEaseType", targ.movingEaseType);   // イージングの種類
		});

		// 拡大縮小
		targ.scalable = Group.ToggleGroup(targ.scalable, "Scalable", Direction.vertical, () => {
			targ.scalingDuration = EditorGUILayout.Slider("ScalingDuration", targ.scalingDuration, 0, 3);   // スケーリング時間
			targ.targetScale = EditorGUILayout.Vector2Field("TargetScale", targ.targetScale);               // 目標スケール
			targ.scalingEaseType = (Ease)EditorGUILayout.EnumPopup("ScalingEaseType", targ.scalingEaseType);// イージングの種類
		});

		EditorUtility.SetDirty(target);

		//--------------------------------------------------

		// 複数選択に適応(仮)
		foreach (var target in targets) {
			var subTarg = target as TextControllersParameter;

			subTarg.colorable = targ.colorable;
			subTarg.targetColor = targ.targetColor;

			subTarg.fadable = targ.fadable;
			subTarg.movable = targ.movable;
			subTarg.scalable = targ.scalable;

			EditorUtility.SetDirty(target);
		}

	}
}
