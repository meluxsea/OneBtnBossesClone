using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShot : MonoBehaviour, IEnemySkill
{
    [SerializeField] Vector2[] bulletDirection;
    [SerializeField] Transform[] bulletSpawns;
    private int shotNumber = -1;


    public void Skill()
    {
        InvokeRepeating("ShootBullet", 0, 1);
    }


    private void ShootBullet()
    {
        shotNumber++;

        if (shotNumber < bulletSpawns.Length)
        {
            GameObject enemyBullet = Factory.instance.CreateRecyclableObject("EnemyBullet", bulletSpawns[shotNumber]);
            enemyBullet.GetComponent<EnemyBullet>().LaunchBullet(bulletDirection[shotNumber]);
        }
        else
        {
            CancelInvoke("ShootBullet");
            shotNumber = -1;
        }
    }
}
