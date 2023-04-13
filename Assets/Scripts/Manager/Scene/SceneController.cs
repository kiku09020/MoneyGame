using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneController : SceneControllerBase<SceneController>
{
    //-------------------------------------------
    /// <summary>
    /// ���݂̃V�[����ǂݍ���
    /// </summary>
    public void LoadNowScene()
    {
        SceneManager.LoadScene(NowScene.SceneIndex);
    }

    /// <summary>
    /// ���̃V�[����ǂݍ���
    /// </summary>
    public void LoadNextScene()
    {
        if (CheckNextSceneIndex()) {
            SceneManager.LoadScene(NowScene.SceneIndex + 1);
        }
    }

    /// <summary>
    /// �O�̃V�[����ǂݍ���
    /// </summary>
    public void LoadPrevScene()
    {
        if (CheckPrevSceneIndex()) {
            SceneManager.LoadScene(NowScene.SceneIndex - 1);
        }
    }

    //-------------------------------------------

    /// <summary>
    /// �V�[���ԍ��w��œǂݍ���
    /// </summary>
    public void LoadScene(int index)
    {
        // �ǂݍ���
        if (index > 0 && index < sceneCount) {
            SceneManager.LoadScene(index);
        }

        // �x��
        else {
            Debug.LogWarning("�w�肳�ꂽ�V�[���ԍ��̃V�[���͑��݂��܂���B");
        }
    }

    /// <summary>
    /// �V�[�����w��œǂݍ���
    /// </summary>
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
