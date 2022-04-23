using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public float maxLifeTime;

    private float _lifeTime = 0.0f;

    void Update()
    {
        _lifeTime += Time.deltaTime;
        
        //Destroy Projectile if over max Lifetime
        if (_lifeTime >= maxLifeTime)
        {
            speed = 0;
            Destroy(gameObject);
        }
        
        //Update position of Projectile
        else
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy_Ghost"))
        {
            //damage Enemy
           other.GetComponent<EnemyDamageDeath>().enemyHit(gameObject);
           
           //destroy Projectile
           speed = 0;
           Destroy(gameObject);
        }
    }
    
}
