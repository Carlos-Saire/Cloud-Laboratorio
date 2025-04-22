using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBulletEnemy : MonoBehaviour
{
    public GameObject Bullet;
    public void GenerarBullet(float Direction)
    {
       GameObject Go= Instantiate(Bullet, transform.position, transform.rotation);
        Go.GetComponent<BulletController>().Xdirection = -Direction;
    }
}
