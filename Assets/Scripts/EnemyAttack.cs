using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ShootBullet
{
    [SerializeField] List<Transform> bulletSpawners;
    [SerializeField] List<Vector2> bulletDirection;


    void Start()
    {
        InvokeRepeating("ShootMultipleBullets", shotInitialTime, shotCooldown);
    }


    private void ShootMultipleBullets()
    {
        for (int i = 0; i < bulletSpawners.Count; ++i)
        {
            Shot(bulletDirection[i], bulletSpawners[i], bulletSpawners[i].rotation);
        }
    }
}
