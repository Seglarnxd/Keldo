//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool isFalling = false;

    private bool movingRight = true;
    private new Rigidbody2D rigidbody;

    [SerializeField] private float pathTime;
    private float timeSinceLastPathChange;

    public Transform groundCheck;

    private void Start()
    {
        timeSinceLastPathChange = Time.time;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.time - timeSinceLastPathChange > pathTime)
        {
            timeSinceLastPathChange = Time.time;
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        
        
        
        if (groundInfo.collider == false && !isFalling)
        {
            if (movingRight == true && Mathf.Abs(rigidbody.velocity.x) < 10)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else if (Mathf.Abs(rigidbody.velocity.x) < 10)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

            isFalling = true;
        }

        if (groundInfo.collider == true)
            isFalling = false;

        //if (isFalling)
        //    rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
    }
}
