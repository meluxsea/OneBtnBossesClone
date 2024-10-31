using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBullet : Bullet
{
    [SerializeField] float rotationSpeed;
    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }


    private void FixedUpdate()
    {
        Vector2 targetPosition = transform.position - target.position;
        targetPosition.Normalize();

        float value = Vector3.Cross(targetPosition, transform.right).z;

        _rb.angularVelocity = rotationSpeed * value;
        _rb.velocity = transform.right * bulletSpeed;
    }
}
