using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;//

public class JumpEvent : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private LayerMask layerInteractue;
    private float distance = 1.03f;
    private Vector2 direction = Vector2.down;
    private RaycastHit2D hit;
    private bool isOneJump;
    private bool isDoubleJump;
    private bool isJump;
    public event Action jumpEvent;

    protected virtual void ActiveEventJump()
    {
        jumpEvent?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true; 
        }
    }
    private void FixedUpdate()
    {
        CheckRaycast();
        if (isJump==true)
        {
            if (isOneJump==true)
            {
                ActiveEventJump(); 
                isJump = false;     
                isOneJump = false; 
            }
            else if (isDoubleJump == true)
            {
                ActiveEventJump();  
                isJump = false;     
                isDoubleJump = false; 
            }
        }
    }

    private void CheckRaycast()
    {
        hit = Physics2D.Raycast(origin.position, direction, distance, layerInteractue);
        if (hit.collider != null)
        {
            isOneJump = true;      
            isDoubleJump = true;
        }
        else
        {
            isOneJump=false;
        }
    }
}
