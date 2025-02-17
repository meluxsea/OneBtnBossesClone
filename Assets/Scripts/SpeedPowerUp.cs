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
      PowerUpEffect();
    }



    public void PowerUpEffect()
    {
        if (Input.GetKey(KeyCode.A)/*&& !canChangeDirection*/)// cuando toca el power up, la barra es de 100 y va bajando poco a poco y se deja de tener el efecto, vuelve arecargar al tocar el power up
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
