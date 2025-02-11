using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("POOL OBJECT")]

    [SerializeField] private List<GameObject> pooledPrefabs;

    [SerializeField] int amountToPool;

    [SerializeField] GameObject[] objectPrefabs;

    int objectNumber = 0;



    void Start()
    {
        AddObjectToPool(amountToPool);
    }



    private void AddObjectToPool(int quantityToAdd)
    {
        for (int i = 0; i < quantityToAdd; i++)
        {
            if (objectPrefabs.Length > 1)
            {
                objectNumber = Random.Range(0, objectPrefabs.Length);
            }

            GameObject obstacle = Instantiate(objectPrefabs[objectNumber]);
            obstacle.SetActive(false);
            pooledPrefabs.Add(obstacle);

            obstacle.transform.parent = transform;
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledPrefabs[i].activeSelf)
            {
                if (pooledPrefabs[i] != null)
                {
                    pooledPrefabs[i].SetActive(true);
                    return pooledPrefabs[i];
                }
            }
        }
        AddObjectToPool(1);
        pooledPrefabs[pooledPrefabs.Count - 1].SetActive(true);
        return pooledPrefabs[pooledPrefabs.Count - 1];
    }
}
