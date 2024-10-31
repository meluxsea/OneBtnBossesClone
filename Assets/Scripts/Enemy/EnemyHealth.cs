using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;

    private void TakeDamage()
    {
        health--;

        if (health >= 0) 
        {
            Debug.Log("Destruir enemigo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            TakeDamage();
    }
}
