using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 10;
    [SerializeField] ParticleSystem hitEffect;

    [Header("Camera Shake")]
    [SerializeField] bool applyCameraShake;
    [SerializeField] float traumaDecay = 0.1f;
    [SerializeField] float traumaIncrease = 0.5f;
    [SerializeField] int traumaFactor = 2;
    CameraShake cameraShake;
    float trauma = 0;
    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    public int GetHealth(){
        return health;
    }

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
   
            TakeDamage(damageDealer.GetDemage());
            PlayerHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void Update() {

        trauma = Mathf.Clamp(trauma - traumaDecay, 0, 1);
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play(Mathf.Pow(trauma, traumaFactor));
        }
    }

    void TakeDamage(int damage){
        health -= damage;
        if(audioPlayer!=null){
            audioPlayer.PlayerDamageTakingClip();
        }
        if(applyCameraShake){
            trauma = Mathf.Clamp(trauma + traumaIncrease, 0, 1);
        }
        if(health <= 0){

          Die();
        
        }

    }

    void Die(){
        if(!isPlayer){
            scoreKeeper.AddScore(score);
            }
        Destroy(gameObject);
    }

    void PlayerHitEffect(){
        if(hitEffect == null) return;
        ParticleSystem instance = Instantiate(hitEffect,
         transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);


    }


}
