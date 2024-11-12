using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] Vector2[] bulletDirection;
    [SerializeField] Transform[] bulletSpawn;
    [SerializeField] EnemyBullet bulletPrefab;

    [Header("TIME")]
    [SerializeField] float initialTime;
    [SerializeField] float shootCoolDown;


    void Start()
    {
        InvokeRepeating("ShootBullet", initialTime, shootCoolDown * bulletSpawn.Length);
    }


    private void ShootBullet()
    {
        for (int i = 0; i < bulletSpawn.Length; i++)
        {
            EnemyBullet enemyBullet = Instantiate(bulletPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation);
            enemyBullet.LaunchBullet(bulletDirection[i]);
            //StartCoroutine(WaitForShootBullet(i));
        }
    }

    private IEnumerator WaitForShootBullet(int j)
    {
        EnemyBullet enemyBullet = Instantiate(bulletPrefab, bulletSpawn[j].position, bulletSpawn[j].rotation);
        enemyBullet.LaunchBullet(bulletDirection[j]);

        yield return new WaitForSeconds(shootCoolDown);
    }
}
