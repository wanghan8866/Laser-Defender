using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautsMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        RotateTowards(target.position);
        }

    private void RotateTowards(Vector2 target)
    {        
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        var offset = -90f;
        
        // transform.rotation = Quaternion.Euler(Vector3.forward * (angle  + offset));
        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            Quaternion.Euler(Vector3.forward * (angle  + offset)), 
            Time.deltaTime * rotationSpeed);
    }
}
