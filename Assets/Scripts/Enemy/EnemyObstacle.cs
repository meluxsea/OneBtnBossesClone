using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject obstaclePrefab;
    private GameObject obstacle;
    private int randomAngle;

    [Header("COOLDOWN")]
    [SerializeField] float invokeCooldown;



    void Start()
    {
        InvokeRepeating("ObstaclePositionAndState", 1, invokeCooldown + 3+5);
    }


    
    private void ObstaclePositionAndState()
    {
        obstacleRotation();
        StartCoroutine(ActivateObstacle()); 
    }

    private void obstacleRotation()
    {
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
        randomAngle = Random.Range(0, 360);
    }

    IEnumerator ActivateObstacle()
    {
        obstacle = Instantiate(obstaclePrefab, centerPosition.transform.position, centerPosition.transform.rotation); 

        yield return new WaitForSeconds(3);

        obstacle.GetComponent<Collider2D>().enabled = true;
        obstacle.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(5);

        Destroy(obstacle);
    } 
}

