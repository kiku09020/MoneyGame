using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class SceneControllerBase<T> : Singleton<T> where T:SceneControllerBase<T>
{
    protected static int sceneCount;

    protected override void Awake()
    {
        NowScene.Setup();       // ���݂̏�Ԃ̃Z�b�g�A�b�v

        // �C�x���g�ǉ�
        SceneManager.sceneLoaded += SceneLoaded;
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    // �ǂݍ��݊������̏���
    static void SceneLoaded(Scene scene,LoadSceneMode sceneMode)
    {
        NowScene.Setup();

        /* �����ɏ�����ǉ� */
        BGM.Instance.Stop();
    }

    /// <summary>
    /// �w�肳�ꂽindex�̃V�[�������݂��邩�`�F�b�N
    /// </summary>
    protected static bool CheckSceneIndex(int index)
    {
		if (index > 0 && index < sceneCount) {
            return true;
        }

        return false;
	}

    /// <summary>
    /// ���̃V�[���̓ǂݍ��݃`�F�b�N
    /// </summary>
    protected static bool CheckNextSceneIndex()
    {
        var index = NowScene.SceneIndex + 1;

        if (index < sceneCount) {
            return true;
        }

        else {
            Debug.LogWarning("���̃V�[���͑��݂��܂���B");
            return false;
        }
    }

    /// <summary>
    /// �O�̃V�[���̓ǂݍ��݃`�F�b�N
    /// </summary>
    protected static bool CheckPrevSceneIndex()
    {
        var index = NowScene.SceneIndex - 1;

        if (0 <= index) {
            return true;
        }

        else {
            Debug.LogWarning("�O�̃V�[���͑��݂��܂���B");
            return false;
        }
    }
}
