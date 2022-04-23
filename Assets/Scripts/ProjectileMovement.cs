using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public float lifeTime;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.right * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Speed not set!");
        }
    }
}
