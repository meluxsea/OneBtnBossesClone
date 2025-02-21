using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour, IEnemySkill
{
    private readonly string[] obstacleNames = { "TriangleObstacle", "RectangleObstacle" }; //Se añaden los nombres de los obstaculos disponibles

    [Header("SCREEN CENTER")]
    [SerializeField] GameObject centerPosition;

    [Header("COLORS")]
    [SerializeField] Color ActivationColor;
    [SerializeField] Color DesactivationColor;



    public void Skill()
    {
        RotateObstacle();
        StartCoroutine(ActivateObstacle());
    }

   
    IEnumerator ActivateObstacle()
    {
        string obstacleName = GetRandomObstacleName();
        GameObject obstacle = Factory.instance.CreateRecyclableObject(obstacleName, centerPosition.transform);

        SetObstacleState(obstacle, false, DesactivationColor);
        yield return new WaitForSeconds(2.5f);

        SetObstacleState(obstacle, true, ActivationColor);
        yield return new WaitForSeconds(4);

        obstacle.SetActive(false);
    }

    private void RotateObstacle()
    {
        centerPosition.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    private void SetObstacleState(GameObject obstacle, bool colliderState, Color color)
    {
        obstacle.GetComponent<Collider2D>().enabled = colliderState;
        obstacle.GetComponent<SpriteRenderer>().color = color;
    }

    private string GetRandomObstacleName()
    {
        return obstacleNames[Random.Range(0, obstacleNames.Length)];
    }
}

