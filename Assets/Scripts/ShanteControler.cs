using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShanteControler : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    public ControlerBarrido barrido;
    public float Speed;
    public GameObject Activar;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public AudioSource Sounds;
    public CambioScene Scene;
    AudioSource AudioSource;
    bool confir=false;
    bool booltime;
    public float time;
    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        spriteRenderer.flipX = true;
    }
    private void Update()
    {
        if (confir == true)
        {
            Festejo();
            confir = false;
            booltime = true;
        }
        if (booltime == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                barrido.SetActiveAnimationSalida();
                Scene.LoadScene("Lomo Saltado Win", 1);
                booltime = false;
            }
        }
    }
    void Festejo()
    {
        Sounds.Stop();
        AudioSource.Play();
        animator.SetTrigger("Festejo");
    }
    private void FixedUpdate()
    {
        rigidbody2.linearVelocity=new Vector2 (-Speed*Time.deltaTime,0);
    }
    public void Confirmar()
    {
        confir = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Resepcion")
        {
             Activar.SetActive(true);
             animator.SetTrigger("Parada");
        }
    }
}
