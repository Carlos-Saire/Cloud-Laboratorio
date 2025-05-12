using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    private Scrollbar SCB;
    [SerializeField] private PlayerController Player;
    private void Awake()
    {
        SCB = GetComponent<Scrollbar>();
    }
    private void LifeInteratue(int Life)
    {
        SCB.size = (float)Life/10;
    }
    private void OnEnable()
    {
        Player.EventLife += LifeInteratue;
    }
    private void OnDisable()
    {
        Player.EventLife -= LifeInteratue;
    }
}
