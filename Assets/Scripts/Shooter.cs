using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;

    [SerializeField] float fireRate = 1f;
    [Header("AI General")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFireTime = 0.1f;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;
    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
        
    }


    void Update()
    {
        Fire();
        
    }

    void Fire(){
        if(isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine!=null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }
    public float GetRandomFireTime(){

        float spawnTime = Random.Range(
            fireRate - firingRateVariance,
            fireRate + firingRateVariance);
        return Mathf.Clamp(spawnTime, minimumFireTime, float.MaxValue);

    }

    IEnumerator FireContinuously(){
        while(isFiring){

            

            GameObject laser = Instantiate(projectilePrefab, 
            transform.position, Quaternion.identity);
            Rigidbody2D rb2 = laser.GetComponent<Rigidbody2D>();
            if(rb2!=null){
                rb2.velocity = transform.up*projectileSpeed;
            }
            
            Destroy(laser, projectileLifetime);
            
            audioPlayer.PlayerShootingClip();

            yield return new WaitForSeconds(GetRandomFireTime());
        }


    }
}
