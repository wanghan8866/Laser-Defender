using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip DamageTakingClip;
    [SerializeField] [Range(0f, 1f)] float DamageTakingVolume = 1f;

    static AudioPlayer instance;
    public AudioPlayer GetInstance(){
        return instance;
    }

    private void Awake() {
        ManageSingleton();
    }

    void ManageSingleton(){
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // instance = 
        if(instance != null){
            instance.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
            instance.GetComponent<AudioSource>().Play();

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    
    public void PlayerShootingClip(){

        PlayerClip(shootingClip, shootingVolume);

        
    }
    public void PlayerDamageTakingClip(){
        PlayerClip(DamageTakingClip, DamageTakingVolume);
    }

    private void PlayerClip(AudioClip audioClip, float volume){
        if(audioClip != null){
            AudioSource.PlayClipAtPoint(
                audioClip, 
                Camera.main.transform.position,
                volume
                );

        }
    }
}
