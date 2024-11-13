using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IEnemySkill
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject[] attacksPrefabs;
    private GameObject obstacle;
    private int randomAngle;
    private int randomObstacleType;

    /* [Header("COOLDOWN")]
      [SerializeField] float invokeCooldown;



      void Start()
      {
          InvokeRepeating("ObstaclePositionAndState", 1, invokeCooldown + 3+5);
      }*/

    public void Skill()
    {
        ObstaclePositionAndState();
    }



    private void ObstaclePositionAndState()
    {
        obstacleRotation();
        StartCoroutine(ActivateRandomObstacle()); 
    }

    private void obstacleRotation()
    {
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
        randomAngle = Random.Range(0, 360);
    }

    IEnumerator ActivateRandomObstacle()
    {
        obstacle = Instantiate(attacksPrefabs[randomObstacleType], centerPosition.transform.position, centerPosition.transform.rotation);
        randomObstacleType = Random.Range(0, attacksPrefabs.Length);

        yield return new WaitForSeconds(3);

        obstacle.GetComponent<Collider2D>().enabled = true;
        obstacle.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(5);

        Destroy(obstacle);
    }

   
}

