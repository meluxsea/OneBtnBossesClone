using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] float radius;
    [SerializeField] float angle;
    private bool direction;
    public float speed;



    void Update()
    {
        circularMovement();
    }



    private void circularMovement()
    {
        float x = center.position.x + Mathf.Cos(angle) * radius;
        float y = center.position.y + Mathf.Sin(angle) * radius;
        float z = center.position.z;


        transform.position = (new Vector3(x, y, z));
        Rotation();


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


    public void ChangeDirection()
    {
        if (GameManager.managerInstance.canChangeDirection == true)
        {
            direction = !direction;
        }
    }


    private void Rotation()
    {
        Vector3 look = transform.InverseTransformPoint(center.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);
    }
}
