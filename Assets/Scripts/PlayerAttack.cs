using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : ShootBullet
{
    [SerializeField] Transform bulletSpawn;

    private void Start()
    {
        InvokeRepeating("ShotOneBullet", shotInitialTime, shotCooldown);
    }

    private void ShotOneBullet()
    {
        Shot(transform.up, bulletSpawn, transform.rotation);
    }
    
}
