using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] Slider powerUpLoad;
    [SerializeField] int speedBoost;


    void Start()
    {
        powerUpLoad.maxValue = 100;
        powerUpLoad.minValue = 0;
    }

    
    void Update()
    {
        powerUpLoad.value += Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
        {
            if (powerUpLoad.value > 0)
            {
                gameObject.GetComponent<PlayerMovement>().speed = gameObject.GetComponent<PlayerMovement>().speed + speedBoost;
                powerUpLoad.value -= Time.deltaTime;
            }    
        }

        //CUANDO SE PRESIONA EL CAMBIO DE DIRECCION, SE ACTIVA EL POWER UP (SE USA EL CARGADOR CUANDO SE MANTIENE LA FLECHA)
    }
}
