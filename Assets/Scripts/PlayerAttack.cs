using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform targetPosition;

    [SerializeField] float shotCooldown;
    [SerializeField] float shotInitialTime;


    private void Start()
    {
        InvokeRepeating("Shot", shotInitialTime, shotCooldown);
    }


    private void Shot()
    {
        Bullet projectile = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        projectile.LaunchBullet(transform.up);
    }
}
