using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : Health
{
    protected override void HealthIsZero()
    {
        GameManager.managerInstance.activatePanel(GameManager.managerInstance.gameOverPanel);
    }
}

