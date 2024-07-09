using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    [SerializeField] float shakeOffsetMagnitude = 0.5f;
    Vector3 initialPosition;
    Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation ;
        // Debug.Log(initialRotation.eulerAngles);
    }

    public void Play(float amount = 1f){
        StartCoroutine(Shake(amount));
    }

    IEnumerator Shake(float amount = 1f){
        float timer = 0f;
        
        Debug.Log($"Shape Amount: {amount}");
        // Debug.Log($"Shape Noise: {Mathf.PerlinNoise(0, 0)}");
        while(timer < shakeDuration * amount){
               transform.position = initialPosition + (Vector3) Random.insideUnitCircle * shakeMagnitude * amount;
               transform.rotation = Quaternion.Euler(initialRotation.eulerAngles + (Vector3) Random.insideUnitCircle * shakeOffsetMagnitude * amount);
               timer += Time.deltaTime;
               yield return new WaitForEndOfFrame();
        }
     
        

        transform.position = initialPosition;
        transform.rotation = initialRotation;

    }


}
