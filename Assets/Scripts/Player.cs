using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    Vector2 rawInput;
    [SerializeField] float moveSpeed = 10;

    // top left bottom right
    [SerializeField] float [] paddings = new float [4];
    Vector2 minBound;
    Vector2 maxBound;
    Shooter shooter;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }
    
    private void Start() {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds(){
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    public float[] GetPadding(){
        return paddings;
    }

    public Vector2 GetMinBound(){
        return minBound;
    }
    public Vector2 GetMaxBound(){
        return maxBound;
    }

    private void Move()
    {
        Vector3 delta = rawInput;
        Vector3 newPosition = transform.position + delta * Time.deltaTime * moveSpeed;
        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x + paddings[1], maxBound.x - paddings[3]);
        newPosition.y = Mathf.Clamp(newPosition.y, minBound.y + paddings[2], maxBound.y - paddings[0]);
        
        transform.position = newPosition;
    
    }

    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    void OnFire(InputValue value){
        // Debug.Log(value.Get<Vector2>());
        if(shooter != null){
            shooter.isFiring = value.isPressed;
        }
    }
}
