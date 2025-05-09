using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerBarrido : MonoBehaviour
{
    Animator animator;
    public bool _Entrada;
    bool _Salida;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        if(_Entrada == true)
        {
            animator.SetTrigger("Entrada");
        }
    }
    void Update()
    {
        if(_Salida == true)
        {
            animator.SetTrigger("Salida");
        }
    }
    public void SetActiveAnimationSalida()
    {
         _Salida = true;
    }
}
