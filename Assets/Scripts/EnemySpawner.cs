using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWave = 0f;
    [SerializeField] bool isLooping = true;
    int waveIndex = 0;
    void Start()
    {
        StartCoroutine(SpwanEnemiesInWaves());
    }

    public WaveConfigSO GetWaveConfigSO(){
        return waveConfigs[waveIndex];
    }

    private IEnumerator SpwanEnemiesInWaves()
    {   
        do
        {
            for (waveIndex = 0; waveIndex < waveConfigs.Count; waveIndex ++){
                WaveConfigSO currentWave = waveConfigs[waveIndex];
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                        currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWayPoint().position,
                        Quaternion.Euler(new Vector3(0, 0, 180)),
                        transform
                    );
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWave);
            }
            
        } while (isLooping);

     
    
    }
}
