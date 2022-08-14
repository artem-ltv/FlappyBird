using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject obstacle))
            {
                _elapsedTime = 0;
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                obstacle.SetActive(true);
                obstacle.transform.position = spawnPoint;

                DisableObjects();
            }
        }
    }
}
