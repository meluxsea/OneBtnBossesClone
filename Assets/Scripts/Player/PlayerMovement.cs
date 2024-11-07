using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] Transform center;
    [SerializeField] float radius;
    [SerializeField] float angle;
    private bool direction;
    public float speed;




    void Update()
    {
        circularMovement();
        ChangeDirection();
    }



    private void circularMovement()
    {
        float x = center.position.x + Mathf.Cos(angle) * radius;
        float y = center.position.y + Mathf.Sin(angle) * radius;
        float z = center.position.z;


        transform.position = (new Vector3(x, y, z));


        switch (direction)
        {
            case true:
                angle -= speed + Time.deltaTime;
                break;

            case false:
                angle += speed + Time.deltaTime;
                break;
        }  
    }


    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.A) /*Y SI NO ESTA ACTIVADO EL POWER UP DE VELOCIDAD*/)
        {
            direction = !direction;
        }
    }
}
