using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform enemy;

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float shotCooldown;
    [SerializeField] protected float shotInitialTime;


    private void Start()
    {
        InvokeRepeating("ShotOneBullet", shotInitialTime, shotCooldown);
    }

    private void ShotOneBullet()
    {
        if (enemy != null) { Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation); } 
    }
}
