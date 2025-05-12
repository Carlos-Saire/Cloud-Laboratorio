using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private int point;
    [SerializeField] private GameObject Winer;
    [SerializeField] private GameObject Fail;
    public static event Action<int> EventPoint;
    [SerializeField] private TMP_Text textWin;
    [SerializeField] private TMP_Text textLosue;
    [SerializeField] private CounterController Counter;
    private void Start()
    {
        ActiveEvetPoint();
    }
    public void TimeGame(int time)
    {
        Time.timeScale = time;
    }
    protected virtual void ActiveEvetPoint()
    {
        EventPoint?.Invoke(point);
    }
    private void IncreasePoints(int point)
    {
        this.point = this.point+point;
        ActiveEvetPoint();
    }
    private void ActiveWin()
    {
        Winer.SetActive(true);
        textWin.text = "Time: " + Counter.Counter();
        TimeGame(0);
    }
    private void ActiveLosue()
    {
        Fail.SetActive(true);
        textLosue.text = "Time: " + Counter.Counter();
        TimeGame(0);
    }
    private void OnEnable()
    {
        IncrementPoint.EventIncrementPoint += IncreasePoints;
        PlayerController.EventWin += ActiveWin;
        PlayerController.EventLouse += ActiveLosue;
    }
    private void OnDisable()
    {
        IncrementPoint.EventIncrementPoint -= IncreasePoints;
        PlayerController.EventWin -= ActiveWin;
        PlayerController.EventLouse -= ActiveLosue;

    }
}