using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject[] attacksPrefabs;
    private GameObject obstacle;
    private int randomAngle;
    private int randomObstacleType;



    private void Start()
    {
        InvokeRepeating("Skill", 1, 8);
    }

    public void Skill()
    {
        Debug.Log("SKILL");
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
        InstantiateRandomObstacle();
        yield return new WaitForSeconds(3);
        ActivateObstacleCollider();
        yield return new WaitForSeconds(5);
        Destroy(obstacle);
    }

  
    private void ActivateObstacleCollider()
    {
        if (obstacle != null)
        {
            obstacle.GetComponent<Collider2D>().enabled = true;
            obstacle.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void InstantiateRandomObstacle()
    {
        obstacle = Instantiate(attacksPrefabs[randomObstacleType], centerPosition.transform.position, centerPosition.transform.rotation);
        randomObstacleType = Random.Range(0, attacksPrefabs.Length);
    }
}

