using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class SpeedPowerUpController : MonoBehaviour
{
    private PlayerInputAction inputAction;
    public bool isUsingPowerUp;


    private void Awake()
    {
        inputAction = new PlayerInputAction();

        inputAction.PlayerMovement.UseSpeedPowerUp.started += context => StartPowerUp();
        inputAction.PlayerMovement.UseSpeedPowerUp.canceled += context => CancelPowerUp();

    }


    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

 
    private void StartPowerUp()
    {
        isUsingPowerUp = true;
    }

    private void CancelPowerUp()
    {
        isUsingPowerUp = false;
    }
}
