using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void HealthIsZero()
    {
        Destroy(gameObject);
        GameManager.managerInstance.Win();
    }
}
