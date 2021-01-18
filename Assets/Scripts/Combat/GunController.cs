using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public void ShootBullet(){
        Instantiate(Bullet, FirePoint.position, transform.parent.rotation);
    }
}
