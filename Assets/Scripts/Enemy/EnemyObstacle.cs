using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IEnemySkill
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject[] attacksPrefabs;
    private int randomAngle;
    private int randomObstacleType;



    public void Skill()
    {
        obstacleRotation();
        StartCoroutine(ActivateRandomObstacle());
    }

    private void obstacleRotation()
    {
        randomAngle = Random.Range(0, 360);
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
    }

    IEnumerator ActivateRandomObstacle()
    {
        randomObstacleType = Random.Range(0, attacksPrefabs.Length);
        GameObject obstacle = Instantiate(attacksPrefabs[randomObstacleType], centerPosition.transform.position, centerPosition.transform.rotation);
 
        yield return new WaitForSeconds(2.5f);

        obstacle.GetComponent<Collider2D>().enabled = true;
        obstacle.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(4);

        //Destroy(obstacle); //DESACTIVAR
        obstacle.SetActive(false);
    }
}

