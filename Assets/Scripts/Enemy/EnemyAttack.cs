using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyObstacle enemyObstacle;
    [SerializeField] EnemyShot enemyShot;
    [SerializeField] float cooldownSkill = 1;
    private IEnemySkill[] skills;

    
    private void Start()
    {
        skills = new IEnemySkill[] {enemyShot, enemyObstacle };

        InvokeRepeating("SwitchSkills", 1, cooldownSkill);
    }


    private void SwitchSkills()
    {
        int randomNumber = Random.Range(0, skills.Length);
        skills[randomNumber].Skill();
    }
}
