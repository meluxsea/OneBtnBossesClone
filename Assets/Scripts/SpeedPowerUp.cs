using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField][Range(0.0001f, 0.004f)] float speedBoost = 0.0002f;

    [SerializeField] Slider powerUpLoad;

    private float normalSpeed;

    private bool usingPowerUp;



    void Start()
    {
        normalSpeed = gameObject.GetComponent<PlayerMovement>().speed;
        SetSliderValues();
    }

    void Update()
    {
      PowerUpEffect(); //USAR INPUT SYSTEM
    }



    public void PowerUpEffect()
    {
        if (!GameManager.managerInstance.canChangeDirection)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (powerUpLoad.value > 0)
                {
                    PowerUpState(false, gameObject.GetComponent<PlayerMovement>().speed, speedBoost);
                    powerUpLoad.value -= Time.deltaTime * 100;
                }
                else
                {
                    PowerUpState(true, normalSpeed, 0);
                }
            }
            else
            {
                PowerUpState(true, normalSpeed, 0);
                powerUpLoad.value += Time.deltaTime * 100;
            }
        }
        else
            Debug.Log("Player can`t use Speed Power Up");

    }


    private void PowerUpState(bool playerCanTakeDamage, float speed, float aditionalSpeed)
    {
        gameObject.GetComponent<PlayerHealth>().canTakeDamage = playerCanTakeDamage;
        gameObject.GetComponent<PlayerMovement>().speed = speed + aditionalSpeed;
    }


    private void SetSliderValues()
    {
        powerUpLoad.minValue = 0;
        powerUpLoad.maxValue = 100;
        powerUpLoad.value = powerUpLoad.maxValue;
    }
}
