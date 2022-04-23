using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    [Serializable]
    public class SpawnEntry
    {
        public int Path;
        public float SpawnTimer;
        public int EnemyNr;
    }

    [SerializeField]
    private List<GameObject> _enemiesPrefabs = new List<GameObject>();

    [SerializeField]
    private List<Transform> _paths = new List<Transform>();

    [SerializeField]
    private List<SpawnEntry> _spawnList = new List<SpawnEntry>();

    private int _currentSpawn = 0;

    private float _clock=0f;

   

    // Update is called once per frame
    void Update()
    {
        _clock += Time.deltaTime;
        if(_currentSpawn < _spawnList.Count && _spawnList[_currentSpawn].SpawnTimer <= _clock)
        {
            _clock -= _spawnList[_currentSpawn].SpawnTimer;
            GameObject spawnedEnemie = Instantiate(_enemiesPrefabs[_spawnList[_currentSpawn].EnemyNr],transform.position,Quaternion.identity);
            spawnedEnemie.GetComponent<BasicEnemieMoveMent>()._path = _paths[_spawnList[_currentSpawn].Path];
            _currentSpawn++;
        }
    }
}
