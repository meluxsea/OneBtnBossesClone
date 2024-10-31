using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public void LaunchBullet(Vector2 direction)
    {
        _rb.velocity = direction * bulletSpeed;
        Destroy(gameObject, 3f);
    }
}
