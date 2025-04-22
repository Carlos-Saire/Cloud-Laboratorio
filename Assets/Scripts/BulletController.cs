using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    [SerializeField] private float Speed;
    public float Xdirection;
    AudioSource audio;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audio.Play();
    }
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(Speed * Xdirection, 0);
    }
}