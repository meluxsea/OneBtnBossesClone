using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootBullet : MonoBehaviour
{
    [SerializeField] protected Bullet bulletPrefab;

    [SerializeField] protected float shotCooldown;
    [SerializeField] protected float shotInitialTime;


    protected virtual void Shot(Vector2 direction, Transform spawnPosition, Quaternion rotation)
    {
        Bullet projectile = Instantiate(bulletPrefab, spawnPosition.position, rotation);
        projectile.LaunchBullet(direction);
    }
}
