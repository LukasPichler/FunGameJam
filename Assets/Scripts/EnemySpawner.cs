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

    private float _clock=0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
