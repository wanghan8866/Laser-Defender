using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float score;
    static ScoreKeeper instance;
    public static ScoreKeeper GetInstance(){
        return instance;
    }
    private void Awake() {
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);

        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public float GetScore(){
        return score;
    }

    public void SetScore(float value){
        score = Mathf.Clamp(value, 0, int.MaxValue);
        //  Debug.Log($"Curent Score: {score}");
    }

    public void AddScore(float value){
        SetScore(score + value);
    }

    public void ResetScore(){
        score = 0;
    }
}
