using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAlmaController : MonoBehaviour
{
    Transform player;
    public float speed;
    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        AlmaController.Target += SetTarget;
    }
    private void OnDisable()
    {
        AlmaController.Target -= SetTarget;
    }
    private void SetTarget(Transform player)
    {
        this.player=player;

    }
    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;

            }
        }
        
    }

}
