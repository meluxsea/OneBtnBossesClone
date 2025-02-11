using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IEnemySkill
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject[] attacksPrefabs;
    private int randomAngle;

    [Header("ObjectPool")]
    public ObjectPool objectPool;



    public void Skill()
    {
        obstacleRotation();
        StartCoroutine(ActivateObstacle());
    }

    private void obstacleRotation()
    {
        randomAngle = Random.Range(0, 360);
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
    }

    IEnumerator ActivateObstacle()
    {
        GameObject obstacle = objectPool.GetObject();
        obstacle.transform.position = centerPosition.transform.position;
        obstacle.transform.rotation = centerPosition.transform.rotation;

        ObstacleState(obstacle, false, Color.green);

        yield return new WaitForSeconds(2.5f);

        ObstacleState(obstacle, true, Color.red);

        yield return new WaitForSeconds(4);

        obstacle.SetActive(false);
    }

    private void ObstacleState(GameObject obstacle, bool colliderState, Color color)
    {
        obstacle.GetComponent<Collider2D>().enabled = colliderState;
        obstacle.GetComponent<SpriteRenderer>().color = color;
    }
}

