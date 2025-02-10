using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyObstacle enemyObstacle;
    [SerializeField] EnemyShot enemyShot;
    [SerializeField] float cooldownSkill = 1;
    [SerializeField] int randomNumber = 1;


    /*
    private void Start()
    {
        InvokeRepeating("SwitchSkills", 1, cooldownSkill);
    }*/

/*
    private void SwitchSkills()
    {
        Debug.Log("REPETICION");
        randomNumber = Random.Range(1, 2);
        
        switch (randomNumber)
        {
            case 1: enemyShot.GetComponent<IEnemySkill>().Skill();
                break; 

            case 2: enemyObstacle.GetComponent<IEnemySkill>().Skill();
                break;
        }
    }*/
}
