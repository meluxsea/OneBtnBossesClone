using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public bool canChangeDirection;

    [SerializeField] Transform center;
    [SerializeField] float radius;
    [SerializeField] float angle;
    private bool direction;
    public float speed;



    private void Start()
    {
        if (GameObject.FindAnyObjectByType<SpeedPowerUp>() != null)
        {
            Debug.Log("Speed power up is ACTIVE. Player can´t change direction");
            canChangeDirection = false;
        }
        else
            canChangeDirection = true;
    }

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
        if (canChangeDirection)
        {
            direction = !direction;
        }
    }
}
