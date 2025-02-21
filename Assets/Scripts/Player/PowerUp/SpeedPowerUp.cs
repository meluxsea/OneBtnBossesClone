using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField][Range(0.0001f, 0.005f)] float speedBoost = 0.0002f;
    [SerializeField] Slider powerUpLoad;

    private float normalSpeed;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    [Header("INPUT CONTROLLER")]
    public SpeedPowerUpController controller;

    

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>(); 

        normalSpeed = playerMovement.speed;
        SetSliderValues();
    }

    void Update()
    {
      PowerUpEffect();
    }



    public void PowerUpEffect()
    {
        if (GameManager.managerInstance.canChangeDirection) return;
        
        if (controller.isUsingPowerUp && powerUpLoad.value > 0)
        {
            ApplyPowerUp();
        }
        else
        {
            RechargePowerUpLoad();
        }
    }


    private void SetPowerUpState(bool canTakeDamage, float newSpeed)
    {
        playerHealth.canTakeDamage = canTakeDamage;
        playerMovement.speed = newSpeed;
    }

    private void RechargePowerUpLoad()
    {
        SetPowerUpState(true, normalSpeed);
        powerUpLoad.value += Time.deltaTime * 100;
    }

    private void ApplyPowerUp()
    {
        SetPowerUpState(false, playerMovement.speed + speedBoost);
        powerUpLoad.value -= Time.deltaTime * 100;
    }


    private void SetSliderValues()
    {
        powerUpLoad.minValue = 0;
        powerUpLoad.maxValue = 100;
        powerUpLoad.value = powerUpLoad.maxValue;
    }
}
