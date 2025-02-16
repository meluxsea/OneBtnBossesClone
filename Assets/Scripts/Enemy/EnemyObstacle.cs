using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IEnemySkill
{
    [SerializeField] GameObject centerPosition;
    private string obstacleName;
    private int randomNumber;
    private int randomAngle;



    public void Skill()
    {
        obstacleRotation();
        StartCoroutine(ActivateObstacle());
    }

   
    IEnumerator ActivateObstacle()
    {
        RandomObstacleName();
        GameObject obstacle = Factory.instance.CreateRecyclableObject(obstacleName, centerPosition.transform);
        ObstacleState(obstacle, false, Color.green);

        yield return new WaitForSeconds(2.5f);

        ObstacleState(obstacle, true, Color.red);

        yield return new WaitForSeconds(4);

        obstacle.SetActive(false);
    }

    private void obstacleRotation()
    {
        randomAngle = Random.Range(0, 360);
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
    }

    private void ObstacleState(GameObject obstacle, bool colliderState, Color color)
    {
        obstacle.GetComponent<Collider2D>().enabled = colliderState;
        obstacle.GetComponent<SpriteRenderer>().color = color;
    }

    private void RandomObstacleName()
    {
        randomNumber = Random.Range(0, 2);

        switch (randomNumber)
        {
            case 0:
                obstacleName = "TriangleObstacle";
                break;

            case 1:
                obstacleName = "RectangleObstacle";
                break;
        }
    }
}

