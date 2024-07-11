using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 30f;
    Vector2 minBound;
    Vector2 maxBound;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = new Vector3(0, maxBound.y - 1);
        rb.velocity = new Vector2(moveSpeed, 0);
        
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < minBound.x || transform.position.x > maxBound.x ){
            rb.velocity = -rb.velocity ;
        }
        
        
    }
}
