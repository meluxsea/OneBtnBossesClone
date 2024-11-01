using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Health : MonoBehaviour
{
    [SerializeField] protected string bulletTag;
    [SerializeField] protected int health;
    public GameManager manager;


    protected void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
    }


    protected void TakeDamage()
    {  
        health--;

        if (health == 0)
        {
            HealthIsZero();
        }
    }


    protected abstract void HealthIsZero();


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
