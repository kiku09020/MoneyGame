using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyGroup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Button button;

    public RectTransform RectTransform => rectTransform;

    //--------------------------------------------------

    void Awake()
    {
        
    }

    public void ChangeButtonAction(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action.Invoke);
    }
}
