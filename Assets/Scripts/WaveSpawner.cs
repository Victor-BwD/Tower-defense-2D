using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private float spawnDelay;
    
    private int _waveCount = 1;
    private int _currentIndex;
    private int _currentSpawnIndex = 0;
    private int _currentObjectIndex = 0;

    private StartWave _startWave;
    private CountWaves _countWaves;

    void Start()
    {
        _startWave = FindObjectOfType<StartWave>();
        _startWave.OnClick += WaveBegin;

        _countWaves = FindObjectOfType<CountWaves>();
    }

    private void WaveBegin()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while(_currentIndex < objectsToSpawn.Count)
        {
            Instantiate(objectsToSpawn[_currentIndex], spawnPoints[_currentSpawnIndex].transform.position, Quaternion.identity);
            _currentIndex++;

            yield return new WaitForSeconds(spawnDelay);
            
            if (_currentIndex >= objectsToSpawn.Count)
            {
                _currentIndex = 0;
                _currentSpawnIndex++;
                if (_currentSpawnIndex >= spawnPoints.Count)
                {
                    _currentSpawnIndex = 0;
                    _waveCount++;
                    _countWaves.ChangeWaveNumber(_waveCount);

                    if (_waveCount >= 3)
                    {
                        spawnDelay = 1;
                        AddEnemy();
                    }

                    if (_waveCount >= 5)
                    {
                        spawnDelay = 0.5f;
                        AddEnemy();
                    }
                }
            }
        }
    }

    private void AddEnemy()
    {
        GameObject enemyChoosen = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        objectsToSpawn.Add(enemyChoosen);
    }
}
