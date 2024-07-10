using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayer : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private Slider healthSlider;
    private ScoreKeeper scoreKeeper;
    private Health PlayerHealth;
    private float PlayerMaxHealth; 

    private void Awake() {
        
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        healthSlider = GetComponentInChildren<Slider>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        Player player = FindObjectOfType<Player>();
        PlayerHealth = player.GetComponent<Health>();
        
    }
    
    void Start()
    {
        PlayerMaxHealth = PlayerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = PlayerHealth.GetHealth()/PlayerMaxHealth;
        // Debug.Log(healthSlider.value);
        scoreText.text = $"{scoreKeeper.GetScore().ToString().PadLeft(8, '0')}";
        
    }
}
