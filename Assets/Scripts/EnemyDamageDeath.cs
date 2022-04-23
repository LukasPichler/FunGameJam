
using System;
using System.Collections;
using System.Security.Cryptography;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class EnemyDamageDeath : MonoBehaviour
{
    public float health;
    public float fireDmg;
    public float iceDmg;
    public float electroDmg;
    public float fullDissolve;
    public float noDissolve;
    public Color fireColor;
    public Color iceColor;
    public Color electroColor;
    public float timeToDissolve = 3f;
    
    
    private float _currentHealth;
    private bool _isDead = false;
    private float _clock=0f;
    private Renderer _renderer;
    
    //TODO shader/material to play
    

    void Start()
    {
        _currentHealth = health;
    }

    private void Update()
    {
        if (_isDead)
        {
            _clock += Time.deltaTime;
            _renderer.material.SetFloat("_CutoffHeight",Mathf.Lerp(fullDissolve, noDissolve, _clock/timeToDissolve));
            if (_clock / timeToDissolve >= 1)
            {
                Destroy(gameObject);
            }
            //TODO or deathscream here
        }
    }


    public void enemyHit(GameObject projectile)
    {
        if (!_isDead)
        {
            damageEnemy(projectile.tag);
            if (_currentHealth <= 0)
            {
                enemyDeath(projectile.tag);
            }
        }

       
    }

    private void damageEnemy(string projectileTag)
    {
        if (projectileTag. Equals("FireProj"))
        {
            _currentHealth -= fireDmg;
        }
        if (projectileTag.Equals("IceProj"))
        {
            _currentHealth -= iceDmg;
        }
        if (projectileTag.Equals("ElectroProj"))
        {
            _currentHealth -= electroDmg;
        }
    }

    private void enemyDeath(string tag)
    {
        _isDead = true;
        _renderer = gameObject.GetComponent<Renderer>();
        if (tag. Equals("FireProj"))
        {
            _renderer.material.SetColor("_EdgeColor", fireColor);
        }
        if (tag.Equals("IceProj"))
        {
            _renderer.material.SetColor("_EdgeColor", iceColor);
        }
        if (tag.Equals("ElectroProj"))
        {
            _renderer.material.SetColor("_EdgeColor", electroColor);
        }
        
    }
    
}
