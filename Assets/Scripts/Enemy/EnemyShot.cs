using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] Vector2[] bulletDirection;
    [SerializeField] Transform[] bulletSpawn;
    [SerializeField] EnemyBullet bulletPrefab;
    private int randomNumber = -1;

    [Header("TIME")]
    [SerializeField] float initialTime;
    [SerializeField] float shootCoolDown;


    void Start()
    {
        InvokeRepeating("ShootBullet", initialTime, shootCoolDown);
    }


    private void ShootBullet()
    {
        randomNumber++;

        if (randomNumber < bulletSpawn.Length)
        {
            EnemyBullet enemyBullet = Instantiate(bulletPrefab, bulletSpawn[randomNumber].position, bulletSpawn[randomNumber].rotation);
            enemyBullet.LaunchBullet(bulletDirection[randomNumber]);
        }
        else
            randomNumber = -1;
    }
}
