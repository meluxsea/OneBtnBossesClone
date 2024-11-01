using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : Health
{
    protected override void HealthIsZero()
    {
        manager.activatePanel(manager.gameOverPanel);
    }
}

