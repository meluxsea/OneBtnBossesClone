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

        objectByName = new Dictionary<string, RecyclableObject>();

        foreach (var obj in recyclableObjects)
        {
            objectByName.Add(obj.attackName, obj);
        }
    }

    public GameObject CreateRecyclableObject(string objectName, Transform objectTransform)
    {
        Debug.Log("Objetos disponibles en Factory: " + string.Join(", ", objectByName.Keys));

        if (objectByName.TryGetValue(objectName, out RecyclableObject attackPrefab))
        {
            GameObject objectIntance = GameObject.Find(objectName + "Pool").GetComponent<ObjectPool>().GetObject(attackPrefab);

            objectIntance.transform.position = objectTransform.position;
            objectIntance.transform.rotation = objectTransform.rotation;

            return objectIntance;
        }
        else
        {
            Debug.LogWarning($"El obstaculo o bala '{objectName}' no existe en la base de datos de ataques.");
            return null;
        }
    }
}
