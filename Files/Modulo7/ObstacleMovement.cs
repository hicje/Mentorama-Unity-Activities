using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 movementDirection = Vector3.left; 

    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
    }
}
