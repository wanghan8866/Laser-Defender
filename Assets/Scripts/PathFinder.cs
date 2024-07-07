using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfigSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfigSO = enemySpawner.GetWaveConfigSO();
        waypoints = waveConfigSO.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
       if(waypointIndex < waypoints.Count){
        Vector3 targetPosition =  waypoints[waypointIndex].position;
        float delta = waveConfigSO.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        if(transform.position == targetPosition){
            waypointIndex++;
        }
       }else{
        Destroy(gameObject);
       }
    }
}
