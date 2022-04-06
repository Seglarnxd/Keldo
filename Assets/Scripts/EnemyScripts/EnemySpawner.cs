using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private AnimationCurve _distribution;
    [SerializeField] private GameObject[] _objectsToSpawn;

    [Header("Time")] 
    [SerializeField, Tooltip("In seconds.")] private float _timeBeforeFirstSpawn;
    [SerializeField] private float _timeBetweenSpawns;

    private Transform _transform;
    private Coroutine _spawnRoutine;
    private EnemyPool enemyPool;
    [SerializeField] private Transform[] positions = new Transform[4];
    private void Start()
    {
        enemyPool = transform.GetComponent<EnemyPool>();
    }

    private IEnumerator SpawnObjects() {
        yield return new WaitForSeconds(_timeBeforeFirstSpawn);

        while (true) {
            CreateObject();
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }

        void CreateObject() {
            GameObject go = enemyPool.GetEnemy();

            if (go != null)
            {
                int index = Random.Range(0, positions.Length);
                go.transform.position = positions[index].position;
            }
            //     Instantiate(go, _transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private void OnEnable() {
        _spawnRoutine = StartCoroutine(SpawnObjects());
    }

    private void OnDisable() {
        StopCoroutine(_spawnRoutine);
    }

    private void Awake() {
        _transform = transform;
    }
}
