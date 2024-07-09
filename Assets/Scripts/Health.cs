using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
   
            TakeDamage(damageDealer.GetDemage());
            PlayerHitEffect();

            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void PlayerHitEffect(){
        if(hitEffect == null) return;
        ParticleSystem instance = Instantiate(hitEffect,
         transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);


    }
}
