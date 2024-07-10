using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = $"You Scored:\n{ScoreKeeper.GetInstance().GetScore().ToString("00000000")}";
        ScoreKeeper.GetInstance().ResetScore();
    }


}
