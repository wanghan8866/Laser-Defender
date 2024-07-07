using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEmenySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(
            timeBetweenEmenySpawns - spawnTimeVariance,
            timeBetweenEmenySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);

    }

    public Transform GetStartingWayPoint(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints(){
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed(){
        return moveSpeed;
    }

    public int GetEnemyCount(){
        return enemies.Count;
    }

    public GameObject GetEnemyPrefab(int index){
        return enemies[index];
    }

}
