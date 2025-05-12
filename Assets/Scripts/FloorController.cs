using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FloorController : MonoBehaviour
{
    [SerializeField] private JumpEvent jumpEvent;
    [SerializeField] private bool active;
    [SerializeField] private int damage;
    private SpriteRenderer SR;
    public static event Action<int> EventDamge;
    private bool removeLife;
    protected virtual void ActiveEventDamage()
    {
        EventDamge?.Invoke(damage);
    }
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        jumpEvent.jumpEvent += Intercalate;
        this.gameObject.SetActive(active);
    }
    private void Intercalate()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        removeLife = false;

    }
    private void Active(bool a)
    {
        this.gameObject.SetActive (a);
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
