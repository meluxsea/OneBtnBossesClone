using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] Slider powerUpLoad;
    [SerializeField] [Range(0.001f, 0.004f)] float speedBoost;
    private float normalSpeed;


    void Start()
    {
        normalSpeed = gameObject.GetComponent<PlayerMovement>().speed;


        powerUpLoad.maxValue = 100;
        powerUpLoad.minValue = 0;

        powerUpLoad.value = powerUpLoad.maxValue;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Presionar tecla");

            if (powerUpLoad.value > 0)
            {
                gameObject.GetComponent<PlayerHealth>().canTakeDamage = false;
                gameObject.GetComponent<PlayerMovement>().speed = gameObject.GetComponent<PlayerMovement>().speed + speedBoost;
                powerUpLoad.value -= Time.deltaTime * 100;
            }
            else
            {
                gameObject.GetComponent<PlayerHealth>().canTakeDamage = true;
                gameObject.GetComponent<PlayerMovement>().speed = normalSpeed;
                //powerUpLoad.value += Time.deltaTime * 100; //HACER QUE NO SE PUEDA RECARGAR MIENTRAS SE ESTA USANDO LA HABILIDAD
            }    
        }
        else
        {
            gameObject.GetComponent<PlayerHealth>().canTakeDamage = true;
            gameObject.GetComponent<PlayerMovement>().speed = normalSpeed;
            powerUpLoad.value += Time.deltaTime * 100;
        }
        

        //CUANDO SE PRESIONA EL CAMBIO DE DIRECCION, SE ACTIVA EL POWER UP (SE USA EL CARGADOR CUANDO SE MANTIENE LA FLECHA)
    }
}
