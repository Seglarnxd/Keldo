using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    public int damage = 2;
    private float xForce = 200;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!other.gameObject.CompareTag("DoesNotDestroy") && !other.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(gameObject,damage, xForce);
        }
        if (!other.gameObject.CompareTag("DoesNotDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
