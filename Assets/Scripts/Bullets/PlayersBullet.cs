using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBullet : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D _rb;
    Transform target;


    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }


    private void FixedUpdate()
    {
        if (target != null) { ChaseTarget(); } 
    }

    private void ChaseTarget()
    {
        Vector2 targetPosition = transform.position - target.position;
        targetPosition.Normalize();

        float value = Vector3.Cross(targetPosition, transform.right).z;

        _rb.angularVelocity = rotationSpeed * value;
        _rb.velocity = transform.right * bulletSpeed;
    }
}
