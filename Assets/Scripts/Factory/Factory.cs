using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Pool;

public class Factory: MonoBehaviour
{
    public static Factory instance { get; private set; }

    [SerializeField] private RecyclableObject[] recyclableObjects;

    private Dictionary<string, RecyclableObject> objectByName;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        CreateFactoryDictionary();
    }



    private void CreateFactoryDictionary()
    {
        objectByName = new Dictionary<string, RecyclableObject>();

        foreach (var obj in recyclableObjects)
        {
            objectByName.Add(obj.recyclableObjectName, obj);
        }
    }

    public GameObject CreateRecyclableObject(string objectName, Transform objectTransform)
    {
        if (objectByName.TryGetValue(objectName, out RecyclableObject objectPrefab))
        {
            GameObject objectIntance = GameObject.Find(objectName + "Pool").GetComponent<ObjectPool>().GetObject(objectPrefab);
            objectIntance.transform.position = objectTransform.position;
            objectIntance.transform.rotation = objectTransform.rotation;
            return objectIntance;
        }
        else
        {
            Debug.LogWarning($"El obstaculo o bala '{objectName}' no existe en la base de datos de elementos reciclables.");
            return null;
        }
    }
}
