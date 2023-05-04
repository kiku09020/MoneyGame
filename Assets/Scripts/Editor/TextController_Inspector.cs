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

			// �t�F�[�h
			targ.fadable = Group.ToggleGroup(targ.fadable, "Fadable", Direction.vertical, () => {
				targ.inDuration = EditorGUILayout.Slider("FadeInDuration", targ.inDuration, 0, 1);              // �t�F�[�h�C������
				targ.outDuration = EditorGUILayout.Slider("FadeOutDuration", targ.outDuration, 0, 1);           // �t�F�[�h�A�E�g����
				targ.normalDuration = EditorGUILayout.Slider("NormalDuration", targ.normalDuration, 0, 1);      // �ʏ펞��
			});

			// �ړ�
			targ.movable = Group.ToggleGroup(targ.movable, "Movable", Direction.vertical, () => {
				targ.movingDuration = EditorGUILayout.Slider("MovingDuration", targ.movingDuration, 0, 3);      // �ړ�����
				targ.targetPosition = EditorGUILayout.Vector2Field("TargetPosition", targ.targetPosition);      // �ڕW���W
				targ.movingEaseType = (Ease)EditorGUILayout.EnumPopup("MovingEaseType", targ.movingEaseType);   // �C�[�W���O�̎��
			});

			// �g��k��
			targ.scalable = Group.ToggleGroup(targ.scalable, "Scalable", Direction.vertical, () => {
				targ.scalingDuration = EditorGUILayout.Slider("ScalingDuration", targ.scalingDuration, 0, 3);   // �X�P�[�����O����
				targ.targetScale = EditorGUILayout.Vector2Field("TargetScale", targ.targetScale);               // �ڕW�X�P�[��
				targ.scalingEaseType = (Ease)EditorGUILayout.EnumPopup("ScalingEaseType", targ.scalingEaseType);// �C�[�W���O�̎��
			});
		});
	}
}
