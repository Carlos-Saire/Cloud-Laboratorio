using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;//

public class PlayerController : MonoBehaviour
{
    [Header("Player Characteristics")]
    Rigidbody2D RB2D;
    SpriteRenderer SR;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int life;
    private float horizontal;
    [Header("Event")]
    [SerializeField] private JumpEvent jumpEvent;

    public static event Action<bool> buttonIntercalate;
    public event Action<int> EventLife;
    public static event Action EventWin;
    public static event Action EventLouse;
    protected virtual void ActiveEventWin()
    {
        EventWin?.Invoke();
    }
    protected virtual void ActiveEventLouse()
    {
        EventLouse?.Invoke();
    }

    protected virtual void ActiveEventeLife()
    {
        EventLife?.Invoke(life);
    }
    protected virtual void ActiveEventButton(bool a)
    {
        buttonIntercalate?.Invoke(a);
    }
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        RB2D=GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ActiveEventeLife();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        RB2D.linearVelocity=new Vector2(horizontal*speed,RB2D.linearVelocity.y);
    }
    private void Jump()
    {
        RB2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Floor"))
        {
            ActiveEventButton(false);
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            ActiveEventWin();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            ActiveEventLouse();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ActiveEventButton(true);
    }
    private void DamageLife(int life)
    {
        this.life = this.life - life;
        ActiveEventeLife();
        if(this.life <= 0)
        {
            ActiveEventLouse();
        }
    }
    private void IncremenetLife(int life)
    {
        this.life = this.life+life;
        ActiveEventeLife();
    }
    private void OnEnable()
    {
        jumpEvent.jumpEvent += Jump;
        IncrementLife.EventIncrementLife += IncremenetLife;
        EnemyController.EventDamge += DamageLife;
        FloorController.EventDamge += DamageLife;
    }
    private void OnDisable()
    {
        EnemyController.EventDamge -= DamageLife;
        FloorController.EventDamge -= DamageLife;
        IncrementLife.EventIncrementLife -= IncremenetLife;
        jumpEvent.jumpEvent -= Jump;
    }
}
