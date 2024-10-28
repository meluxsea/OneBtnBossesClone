using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] float angle;

    [SerializeField] private int number = 1;

    [SerializeField] Transform target;



    void Update()
    {
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + Mathf.Sin(angle) * radius;
        float z = target.position.z;


        transform.position = (new Vector3(x, y, z));

        angle += speed + Time.deltaTime;
    }
}
