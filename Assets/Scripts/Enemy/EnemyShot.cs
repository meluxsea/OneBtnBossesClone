using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour, IEnemySkill
{
    [SerializeField] Vector2[] bulletDirection;
    [SerializeField] Transform[] bulletSpawns;
    [SerializeField] EnemyBullet bulletPrefab;
    private int shotNumber = -1;



    public void Skill()
    {
        InvokeRepeating("ShootBullet", 1, 1);
    }


    private void ShootBullet()
    {
        shotNumber++;

        if (shotNumber < bulletSpawns.Length)
        {
            EnemyBullet enemyBullet = Instantiate(bulletPrefab, bulletSpawns[shotNumber].position, bulletSpawns[shotNumber].rotation);
            enemyBullet.LaunchBullet(bulletDirection[shotNumber]);
        }
        else
            CancelInvoke("ShootBullet");
    }
}
