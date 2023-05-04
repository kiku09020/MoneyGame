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

		// �x��
		targ.delay = EditorGUILayout.FloatField("Delay", targ.delay);

		// �F
		targ.colorable = Group.ToggleGroup(targ.colorable, "Colorable", Direction.vertical, () => {
			targ.targetColor = EditorGUILayout.ColorField("TargetColor", targ.targetColor);
		});

		// �t�F�[�h
		targ.fadable = Group.ToggleGroup(targ.fadable, "Fadable", Direction.vertical, () => {
			targ.inDuration = EditorGUILayout.Slider("FadeInDuration", targ.inDuration, 0, 1);              // �t�F�[�h�C������
			targ.normalDuration = EditorGUILayout.Slider("NormalDuration", targ.normalDuration, 0, 1);      // �ʏ펞��
			targ.outDuration = EditorGUILayout.Slider("FadeOutDuration", targ.outDuration, 0, 1);           // �t�F�[�h�A�E�g����
		});

		// �ړ�
		targ.movable = Group.ToggleGroup(targ.movable, "Movable", Direction.vertical, () => {
			targ.movingDuration = EditorGUILayout.Slider("MovingDuration", targ.movingDuration, 0, 3);      // �ړ�����
			targ.startPosition = EditorGUILayout.Vector2Field("StartPosition", targ.startPosition);         // �����ʒu
			targ.targetPosition = EditorGUILayout.Vector2Field("TargetPosition", targ.targetPosition);      // �ڕW���W
			targ.movingEaseType = (Ease)EditorGUILayout.EnumPopup("MovingEaseType", targ.movingEaseType);   // �C�[�W���O�̎��
		});

		// �g��k��
		targ.scalable = Group.ToggleGroup(targ.scalable, "Scalable", Direction.vertical, () => {
			targ.scalingDuration = EditorGUILayout.Slider("ScalingDuration", targ.scalingDuration, 0, 3);   // �X�P�[�����O����
			targ.targetScale = EditorGUILayout.Vector2Field("TargetScale", targ.targetScale);               // �ڕW�X�P�[��
			targ.scalingEaseType = (Ease)EditorGUILayout.EnumPopup("ScalingEaseType", targ.scalingEaseType);// �C�[�W���O�̎��
		});

		EditorUtility.SetDirty(target);

		//--------------------------------------------------

		// �����I���ɓK��(��)
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
