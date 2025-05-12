using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonLoadScene : MonoBehaviour
{
    private Button button;
    public static event Action EventExit;
    public static event Action<string> EventLoadScene;
    [SerializeField] private string Scene;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnClik());
    }
    protected virtual void ActiveEventExit() 
    {
        Time.timeScale = 1;
        EventExit?.Invoke();
        Invoke("ActiveEvenSece", 1);
    }
    protected virtual void ActiveEvenSece()
    {
        EventLoadScene?.Invoke(Scene);
    }
    private void OnClik()
    {
        ActiveEventExit();
    }
}
