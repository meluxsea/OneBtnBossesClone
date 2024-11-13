using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObstacle : MonoBehaviour
{
    [SerializeField] GameObject centerPosition;
    [SerializeField] GameObject obstaclePrefab;
    private int randomAngle;
    


    void Start()
    {
        obstaclePrefab.SetActive(false);

        InvokeRepeating("InstantiateObstacle", 1, 1);
    }

    /*
    private void InstantiateObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, centerPosition.transform.position, centerPosition.transform.rotation); //USAR SOLO UN PREFAB
        centerPosition.transform.Rotate(new Vector3(0, 0, randomAngle));
        obstacle.transform.SetParent(centerPosition.transform);

        randomAngle = Random.Range(0, 360);
    }*/
    /*
    IEnumerator ActivateObstacle()
    {
        obstaclePrefab.SetActive(true);
        obstaclePrefab.GetComponent<Collider2D>().enabled = false;
        obstaclePrefab.GetComponent<SpriteRenderer>().color = Color.green;

        //ESPERAR

        obstaclePrefab.GetComponent<Collider2D>().enabled = true;
        obstaclePrefab.GetComponent<SpriteRenderer>().color = Color.red;

        //EPERAR

        obstaclePrefab.SetActive(false);
    }*/
}

