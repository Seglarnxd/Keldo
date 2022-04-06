using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public float invincibilityFrames = 1;
    public float invincibilityTimer = 0;
    public float xForce;

    public void TakeDamage(GameObject damager, int damage, float xForce)
    {
        //Debug.Log("Damage taken !");
        if (Time.time > invincibilityTimer + invincibilityFrames)
        {
            health -= damage;
            invincibilityTimer = Time.time;
            xForce = transform.position.x < transform.position.x ? 100 : -100;
            if (damager.transform.position.x < transform.position.x)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, 0f));
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce * -1, 0f));
            }
        }

        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        {
            //Debug.Log(obj);
            if (obj.CompareTag("Weapon") && Time.time > invincibilityTimer + invincibilityFrames)
            {
                
                Debug.Log($"{Time.time} > {invincibilityTimer} + {invincibilityFrames}");
                    health -= obj.GetComponentInParent<Player>().GetDamage();
                    invincibilityTimer = Time.time;
                    //float xForce = obj.transform.position.x < transform.position.x ? 100 : -100;
                    if (obj.transform.position.x < transform.position.x)
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, 0f));
                    else
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce * -1, 0f));
                    }
            }
            if (health <= 0)
            {
                health = 2;
                gameObject.SetActive(false);
            }
        }
    }
}
