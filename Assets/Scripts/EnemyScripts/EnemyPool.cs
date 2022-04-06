using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{ 
    public GameObject[] enemyPool = new GameObject[10];
    public GameObject enemyPrefab;
    public Transform poolParent;

    public GameObject GetEnemy()
    {
        // finds the first inactive enemy in pool, activates it and returns it
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (!enemyPool[i].activeSelf)
            {
                enemyPool[i].SetActive(true);
                return enemyPool[i];
            }
        }
        return null;
    }

    private void Awake()
    {
        // fills the pool with inactive enemy game objects
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (enemyPool[i] == null)
            {
                enemyPool[i] = Instantiate(enemyPrefab, poolParent);
                enemyPool[i].SetActive(false);
            }
        }
    }
}


