using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    public float currentHealth;
    public float maxHealth;
    public static Player instance;
    public List<IUpdateHealth> pHpListeners = new List<IUpdateHealth>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, maxHealth);
        foreach (var each in pHpListeners)
        {
            each.UpdateHealth();
        }
        //Deletes player
        //Camera acts up if enabled
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int GetDamage()
    {
        return damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
