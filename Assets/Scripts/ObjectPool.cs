using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("POOL OBJECT")]

    [SerializeField] private List<GameObject> pooledPrefabs;

    [SerializeField] int amountToPool;

    [SerializeField] GameObject objectPrefab;



    void Start()
    {
        AddObjectToPool(amountToPool);
    }



    private void AddObjectToPool(int quantityToAdd)
    {
        for (int i = 0; i < quantityToAdd; i++)
        {
            GameObject obstacle = Instantiate(objectPrefab);
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
