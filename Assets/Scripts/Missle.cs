using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float steer = 30f;
    [SerializeField] Transform target;
    Rigidbody2D rb;

    public void SetTarget(Transform t){
        target = t;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        
    }

    private void FixedUpdate() {
        rb.velocity = transform.up * speed * Time.fixedDeltaTime * 10f;
        float rorationSteet;
        if(target == null){
            rorationSteet = 0f;
        }
        else{
            Vector2 direction = (target.position - transform.position).normalized;
            rorationSteet = Vector3.Cross(transform.up, direction).z;
        }

        rb.angularVelocity =  rorationSteet * steer * 10f;

    }
}
