using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBasedSpawner : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] int scoreThreshold;
    int lastTimeScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = ScoreKeeper.GetInstance();
        
    }
    GameObject GetRandGameObject(){
        if(enemies.Count == 0){
            return null;
        }
        int index = Random.Range(0, enemies.Count);
        return enemies[index];
    }

    // Update is called once per frame
    void Update()
    {   
        int current_score = (int) scoreKeeper.GetScore();
        // Debug.Log($"boss: {current_score/scoreThreshold > lastTimeScore}, {current_score/scoreThreshold }, {lastTimeScore}" );
        if(current_score/scoreThreshold > lastTimeScore){
            lastTimeScore = (int) Mathf.Ceil(scoreKeeper.GetScore()/scoreThreshold);
            Debug.Log("Boss here");
            GameObject enemy = GetRandGameObject();

            Instantiate(
                enemy,
                enemy.transform.position,
                Quaternion.Euler(new Vector3(0, 0, 180)),
                transform
            );
        }

    }
}
