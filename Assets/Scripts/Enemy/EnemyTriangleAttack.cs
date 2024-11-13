using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject enemyObstacle;
    [SerializeField] GameObject enemyShot;
    [SerializeField] float cooldownSkill;
    private int randomNumber;



    private void Start()
    {
        InvokeRepeating("SwitchSkills", 1, cooldownSkill);
    }


    private void SwitchSkills()
    {
        randomNumber = Random.Range(1, 2);

        switch (randomNumber)
        {
            case 1:SearchSkillInterface(enemyShot);
                break; 

            case 2: SearchSkillInterface(enemyObstacle);
                break;
        }
        
        
        // SWITCH PARA LLAMAR A LOS DISTINTOS ATAQUES, (VA VARIANDO CADA CIERTO TIEMPO EL ATAQUE A INSTANCIAR)
        // PARA LLAMAR CADA ATAQUE SE USA INTERFACE// BUSCAR UN OBJETO POR TIPO Y ACCERDER A SU INTEFACE
        //PARA EL ATAQUE DE BARRA USAR SCRIPT DE DISPARO
    }

    private void SearchSkillInterface(GameObject attackType)
    {
        attackType.GetComponent<IEnemySkill>().Skill();
    }

    //EL METODO ES UNA RUTINA QUE SIRVE PARA ACTIVAR Y RANDOMIZAR EL ATAQUE, USAR UN METODO ABSTRACTO
    //CADA CLASE HIJA INTEGRA SU LOGICA DE CADA ATAQUE




    //HACER ESTA UNA CLASE PADRE, Y QUE CADA ATAQUE SEA SU CALSE HIJA, ANTES DE INSTANCIAR UN ATAQUE SE VERIFICA SI YA HAY OTRO EN LA ESCENA
}
