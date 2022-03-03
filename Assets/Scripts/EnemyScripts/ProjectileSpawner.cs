using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject serpentProjectile;
    private bool isOnCooldown = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !isOnCooldown)
        {
            Debug.Log("Within line of sight");
            GameObject projectile = Instantiate(serpentProjectile, transform.position, quaternion.identity);
            
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right*250);
            
            StartCoroutine(ActivateCooldown());
        }
    }

    private IEnumerator ActivateCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(1);
        isOnCooldown = false;
    }
}
