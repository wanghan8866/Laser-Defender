using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] List<GameObject> pickups;
    [SerializeField] int scoreThreshold = 100;
    ScoreKeeper scoreKeeper;
    Player player;
    int lastTimeScore = 0;
    private void Awake() {
        
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        scoreKeeper = ScoreKeeper.GetInstance();
    }

    // Update is called once per frame

    GameObject GetRandGameObject(){
        if(pickups.Count == 0){
            return null;
        }
        int index = Random.Range(0, pickups.Count);
        return pickups[index];
    }
    void Update()
    {
        if( scoreKeeper.GetScore()/scoreThreshold > lastTimeScore){
            lastTimeScore = (int)Mathf.Ceil(scoreKeeper.GetScore()/scoreThreshold);
            float[] paddings = player.GetPadding();
            Vector2 minBound = player.GetMinBound();
            Vector2 maxBound = player.GetMaxBound();
         

            float randomX = Random.Range(minBound.x + paddings[1], maxBound.x - paddings[3]);
            float randomY = Random.Range(minBound.y + paddings[2], maxBound.y - paddings[0]);


            Instantiate(
                GetRandGameObject(), 
                new Vector2(randomX, randomY),
                Quaternion.identity
                 );
        }
        
        
    }
}
