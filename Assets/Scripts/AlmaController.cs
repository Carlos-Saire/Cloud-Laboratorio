using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlmaController : MonoBehaviour
{
    Rigidbody2D _rb;
    public float horizontal;
    float vertical;
    public float speed;
    public bool x = true;
    float forceImpulse;
    [Range(0,1)]
    public float speedImpulse;
    public float _threshold;
    Coroutine coroutineImpulse=null;
    public LayerMask mylayerMask;
    public static Action<Transform> Target;
    public CamaraControl camara;
    public bool confirmar = false;

    public float maxX, minX, maxY, minY;
    //public Vector3 playerPos;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //playerPos = this.transform.position;
    }
    // Start is called before the first frame update
    public void SalirAlma()
    {
        coroutineImpulse = StartCoroutine(ImpulseTime(_threshold));
        Target?.Invoke(transform);
        Debug.Log("Inicie");
    }
    private void Update()
    {
        if (this.transform.position.x > maxX)
        {
            this.transform.position = new Vector3(maxX, this.transform.position.y);
        }
        else if(this.transform.position.x < minX)
        {
            this.transform.position = new Vector3(minX, this.transform.position.y);
        }

        if (this.transform.position.y > maxY)
        {
            this.transform.position = new Vector3(this.transform.position.x, maxY);
        }
        else if (this.transform.position.y < minY)
        {
            this.transform.position = new Vector3(this.transform.position.x, minY);
        }
        print(this.transform.position);
    }

    IEnumerator ImpulseTime(float treshold)
    {
        x = false;
       
        forceImpulse = treshold;
        while (forceImpulse >=0 ) 
        {
            _rb.position += Vector2.right*forceImpulse*speedImpulse;

           
            forceImpulse-=Time.deltaTime;
            //Debug.Log(frameRate);
            yield return new WaitForFixedUpdate();
            
        }
        x=true;
        StopCoroutine(coroutineImpulse);
        coroutineImpulse=null;
    }
    private void FixedUpdate()
    {
        if (x == true)
        {
            horizontal = Input.GetAxis("Horizontal") * speed;
            vertical = Input.GetAxis("Vertical") * speed;
            _rb.linearVelocity = new Vector2(horizontal, vertical);
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            }else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAlma")
        {
            Debug.Log("Me Atraparon");
            Fade.onDeath?.Invoke();
            //Derrota
        }
        if (confirmar == true && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().enabled = true;
            collision.gameObject.GetComponent<PlayerController>().Fixed = true;
            camara.Jugador = collision.gameObject;
            //enabled = false;
            this.gameObject.SetActive(false);
            print("Me desactive");
            confirmar = false;
            Target?.Invoke(null);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            confirmar = true;
            print("Confirmo");
        }
    }
    private void OnEnable()
    {
        transform.localPosition = new Vector2(0, 0);
        coroutineImpulse = StartCoroutine(ImpulseTime(_threshold));
        
        confirmar = false;
    }
}
