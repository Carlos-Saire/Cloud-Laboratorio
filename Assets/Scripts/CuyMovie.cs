using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CuyMovie : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    public GameObject NubePlayer;
    public EfectoTexto TextoCuy;
    public GameObject Cuynube;
    public float Speed;
    public Animator animacionPlayer;
    bool Active;
    bool _confirmar;
    Animator _compAnimator;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _compAnimator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (Active)
        {
            Rigidbody.linearVelocity = new Vector2(Rigidbody.linearVelocity.x + Speed * -1*Time.deltaTime, Rigidbody.linearVelocity.y);
        }
    }
    public void SetActiveCaminata()
    { 
        Active = true;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag =="Resepcion")
        {
            _compAnimator.SetTrigger("Parado");
            _confirmar = true;
            Cuynube.SetActive(true);
            CuyDialogo(0);
        }
    }
    public bool Confirmar { get { return _confirmar; } }
    public void CuyDialogo(sbyte n)
    {
        Cuynube.SetActive(true);
        if (n == 0)
        {
            TextoCuy.Inprimir("Buen d�a amigo, cambia esa cara. He venido a ayudarte.");
        }
        if(n == 2)
        {
            TextoCuy.Inprimir("Me llamo frijoles, soy el dios de los restaurantes.");
        }
        if (n == 4)
        {
            animacionPlayer.SetTrigger("Sorprendido");
            TextoCuy.Inprimir("Para tu buena suerte no. Tengo la soluci�n para poder salvar tu restaurante");
        }
        if (n==6)
        {
            TextoCuy.Inprimir("Tienes que aprender a cocinar");
        }
        if (n == 8)
        {
            _confirmar = false;
            TextoCuy.Inprimir(" As� es. Basta de di�logos. �Vamos a la cocina! ");
        }
        NubePlayer.SetActive(false);
    }
}
