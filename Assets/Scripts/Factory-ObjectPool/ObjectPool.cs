using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("POOL OBJECT")]
    [SerializeField] private List<GameObject> pooledPrefabs = new List<GameObject>();


    private void AddObjectToPool(int quantityToAdd, RecyclableObject prefab)
    {
        for (int i = 0; i < quantityToAdd; i++)
        {
            GameObject obstacle = Instantiate(prefab.gameObject);
            obstacle.SetActive(false);
            pooledPrefabs.Add(obstacle);

            obstacle.transform.parent = transform;
        }
    }

    public GameObject GetObject(RecyclableObject prefab)
    {
        for (int i = 0; i < pooledPrefabs.Count; i++)
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
        AddObjectToPool(1, prefab);
        pooledPrefabs[pooledPrefabs.Count - 1].SetActive(true);
        return pooledPrefabs[pooledPrefabs.Count - 1];
    }
}
