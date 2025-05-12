using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarridoController : MonoBehaviour
{
    private Animator AT;
    private void Awake()
    {
        AT = GetComponent<Animator>();
    }
    private void Start()
    {
        AnimacionEnter();
        Time.timeScale = 1;
    }
    private void AnimacionEnter()
    {
        AT.SetTrigger("Enter");
    }
    private void AnimacionExit()
    {
        AT.SetTrigger("Exit");
    }
    private void OnEnable()
    {
        ButtonLoadScene.EventExit += AnimacionExit;
    }
    private void OnDisable()
    {
        ButtonLoadScene.EventExit -= AnimacionExit;
    }
}
