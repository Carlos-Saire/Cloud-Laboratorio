using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IncrementLife : MonoBehaviour
{
    [SerializeField] private int life;
    public static event Action<int> EventIncrementLife;
    protected virtual void ActiveEnvetLife()
    {
        EventIncrementLife?.Invoke(life);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveEnvetLife();
            Destroy(this.gameObject);
        }
    }
}
