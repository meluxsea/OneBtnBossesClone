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

    [Header("ObjectPool")]
    public ObjectPool objectPool;


    private void Start()
    {
        InvokeRepeating("ShotOneBullet", shotInitialTime, shotCooldown);
    }

    private void ShotOneBullet()
    {
        if (enemy != null) 
        {
            Factory.instance.CreateRecyclableObject("PlayerBullet", bulletSpawn);
            //GameObject bullet = objectPool.GetObject();
            //bullet.transform.position = bulletSpawn.position;
        }
    }
}
