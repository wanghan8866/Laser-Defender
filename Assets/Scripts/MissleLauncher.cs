using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    [Header("Missle General")]
    [SerializeField] GameObject misslePrefab;
    [SerializeField] float missleLifeTime = 3f;

    [SerializeField] float fireRate = 3f;
    [SerializeField] ParticleSystem hitEffect;

    [Header("AI General")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFireTime = 0.1f;
    [SerializeField] bool isTargetingPlayer;

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

    // Update is called once per frame
    void Update()
    {
        Launch();
    }

    void Launch(){
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

            

            GameObject missle = Instantiate(misslePrefab, 
            transform.position, transform.transform.rotation);
            if(isTargetingPlayer){
                Player player = FindObjectOfType<Player>();
                if(player != null){
                    missle.GetComponent<Missle>().SetTarget(player.transform);
                }
                
                

            }
            missle.GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(OpenCollider(missle));
            StartCoroutine(SelfDestory(missle));

            // Destroy(missle, missleLifeTime);
            
            audioPlayer.PlayerShootingClip();

            yield return new WaitForSeconds(GetRandomFireTime());
        }


    }

    IEnumerator OpenCollider(GameObject missle){
        yield return new WaitForSeconds(0.1f);
        missle.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    IEnumerator SelfDestory(GameObject missle){
        yield return new WaitForSeconds(missleLifeTime);
        if(missle != null){
            ParticleSystem instance = Instantiate(hitEffect,
            missle.transform.position, missle.transform.rotation);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
            Destroy(missle);
        }


    }

}
