using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBullet : MonoBehaviour
{
    public GameObject Prefab;
    public PlayerController Jugador;
    float Xdirection = 1;
    private void Update()
    {
        if (Jugador.enabled == true&&Jugador.horizontal!=0)
        {
            if (Input.GetMouseButtonDown(0) && GameManagerController.instante.Bullet > 0)
            {
                Debug.Log("Dispare");
                GameObject Go = Instantiate(Prefab, transform.position, transform.rotation);
                Go.GetComponent<BulletController>().Xdirection = Xdirection;
                --GameManagerController.instante.Bullet;
            }
            if (Jugador.horizontal<0)
            {
                Xdirection = -1;
            }
            if (Jugador.horizontal > 0)
            {
                Xdirection = 1;
            }
        }
        

    }
}