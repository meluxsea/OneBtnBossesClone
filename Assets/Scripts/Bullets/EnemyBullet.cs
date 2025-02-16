using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : RecyclableObject
{
    public override string attackName => "EnemyBullet";
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D _rb;


    public void LaunchBullet(Vector2 direction)
    {
        _rb.velocity = direction * bulletSpeed;
        StartCoroutine(DesactivateBullet());
    } 

    IEnumerator DesactivateBullet()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
