using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IncrementPoint : MonoBehaviour
{
    [SerializeField] private int point;
    public static event Action<int> EventIncrementPoint;
    protected virtual void ActiveEventIncrement()
    {
        EventIncrementPoint?.Invoke(point);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveEventIncrement();
            Destroy(this.gameObject);
        }
    }
}
