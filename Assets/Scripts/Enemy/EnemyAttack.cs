using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyObstacle enemyObstacle;
    [SerializeField] EnemyShot enemyShot;
    [SerializeField] float cooldownSkill = 3;
    [SerializeField] int randomNumber = 1;



    private void Start()
    {
        InvokeRepeating("SwitchSkills", 1, cooldownSkill);
    }


    private void SwitchSkills()
    {
        switch (randomNumber)
        {
            case 1: enemyShot.GetComponent<IEnemySkill>().Skill();
                    randomNumber = 2;
                break; 

            case 2: enemyObstacle.GetComponent<IEnemySkill>().Skill();
                    randomNumber = 1;
                break;
        }
    }
}
