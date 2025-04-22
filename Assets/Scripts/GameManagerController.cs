using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    static public GameManagerController instante;
    public float Bullet;
    public ContadorBullet Texto;
    public GameObject[] Vidas;
    private void Awake()
    {
        if (instante == null)
        {
            instante = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        Texto.Contador(Bullet);
    }
}