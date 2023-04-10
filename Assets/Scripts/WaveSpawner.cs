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

                    switch (_waveCount)
                    {
                        case 2:
                            ChangeDelay(1);
                            AddEnemy();
                            break;
                        case 3:
                            ChangeDelay(0.5f);
                            AddEnemy();
                            break;
                        case 5:
                            ChangeDelay(0.3f);
                            AddEnemy();
                            AddEnemy();
                            break;
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

    private void ChangeDelay(float value)
    {
        spawnDelay = value;
    }
}
