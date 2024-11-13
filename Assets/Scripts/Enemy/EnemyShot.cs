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

    /*[Header("TIME")]
    [SerializeField] float initialTime;
    [SerializeField] float shootCoolDown;


    void Start()
    {
        InvokeRepeating("ShootBullet", initialTime, shootCoolDown);
    }*/

    public void Skill()
    {
        //InvokeRepeating("ShootBullet", initialTime, shootCoolDown);
        
        ShootBullet(); //REALIZAR 4 REPETICIONES
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
            shotNumber = -1;
    }

    
}
