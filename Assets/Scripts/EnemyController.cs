using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyController : MonoBehaviour
{
    GameObject Objetive;
    private Vector3 Velocity = new Vector3(0, 0, 0);
    private float direction = -1;
    [SerializeField] private float Speed;
    Vector3 Movi;
    [SerializeField] private float VelocidaDisparo = 0.1f;
    [SerializeField] GenerarBulletEnemy Bullet;
    float Xdirection;
    public bool Iniciar=false;
    public float Vidas=2;
    private void Update()
    {
        
        if (Iniciar == true)
        {
            VelocidaDisparo = VelocidaDisparo - Time.deltaTime;
            if(VelocidaDisparo <= 0)
            {
                Bullet.GenerarBullet(direction);
                VelocidaDisparo = 3;
            }
        }
        if (Vidas == 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Objetive = collision.gameObject;
            if (Vector2.Distance(Objetive.transform.position, this.gameObject.transform.position) > 2)
            {
                Movi = Vector3.SmoothDamp(transform.position, Objetive.transform.position, ref Velocity, Speed);
                transform.position = new Vector3(Movi.x, transform.position.y, transform.position.z);
                if (collision.transform.position.x < this.transform.position.x)
                {
                    direction = 1;                    
                }
                else
                {
                    direction = -1;
                }
                this.transform.localScale = new Vector3(direction*-0.28f, 0.28f, 1);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Iniciar = true;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            --Vidas;
            Destroy(collision.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Iniciar = false;
        }
    }
}