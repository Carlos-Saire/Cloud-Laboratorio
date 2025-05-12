using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject objetivo;
    [SerializeField] private float speed;
    private SpriteRenderer SR;
    public static event Action<int> EventDamge;
    private bool removeLife;
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    protected virtual void ActiveEventDamage()
    {
        EventDamge?.Invoke(damage);
    }
    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SR.color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                removeLife = true;
                RemoveLife();
            }
        }
    }
    public void SetObjetive(GameObject NewObjetivo)
    {
        objetivo = NewObjetivo;
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        removeLife = false;
    }
    private void RemoveLife()
    {
        if (removeLife == true)
        {
            Invoke("RemoveLife", 0.3f);
        }
        ActiveEventDamage();
    }
}
