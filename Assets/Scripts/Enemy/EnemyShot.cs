using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShot : MonoBehaviour, IEnemySkill
{
    [SerializeField] Vector2[] bulletDirection;
    [SerializeField] Transform[] bulletSpawns;
    [SerializeField] EnemyBullet bulletPrefab;
    private int shotNumber = -1;

    [Header("ObjectPool")]
    public ObjectPool objectPool;



    public void Skill()
    {
        InvokeRepeating("ShootBullet", 0, 1);
    }

    private void ShootBullet()
    {
        shotNumber++;

        if (shotNumber < bulletSpawns.Length)
        {
            GameObject enemyBullet = objectPool.GetObject();
            enemyBullet.transform.position = bulletSpawns[shotNumber].position;
            enemyBullet.transform.rotation = bulletSpawns[shotNumber].rotation;

            enemyBullet.GetComponent<EnemyBullet>().LaunchBullet(bulletDirection[shotNumber]);
        }
        else
        {
            CancelInvoke("ShootBullet");
            shotNumber = -1;
        }
    }
}
