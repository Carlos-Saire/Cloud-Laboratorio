using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointController : MonoBehaviour
{
    private TMP_Text Point;
    private void Awake()
    {
        Point = GetComponent<TMP_Text>();
    }
    private void PointsController(int point)
    {
        Point.text = "Point: " + point;
    }
    private void OnEnable()
    {
        GameManagerController.EventPoint += PointsController;
    }
    private void OnDisable()
    {
        GameManagerController.EventPoint -= PointsController;
    }
}
