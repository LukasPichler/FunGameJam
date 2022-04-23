
using System;
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
    
    private float _currentHealth;
    
    //TODO shader/material to play
    

    void Start()
    {
        _currentHealth = health;
    }
    
    public void enemyHit(GameObject projectile)
    {
        //TODO damage Enemy
        damageEnemy(projectile.tag);
        //TODO death animation 
        if (_currentHealth <= 0)
        {
            enemyDeath(projectile.tag);
        }
    }

    private void damageEnemy(string projectileTag)
    {
        if (tag. Equals("FireProj"))
        {
            _currentHealth -= fireDmg;
        }
        if (tag.Equals("IceProj"))
        {
            _currentHealth -= iceDmg;
        }
        if (tag.Equals("ElectroProj"))
        {
            _currentHealth -= electroDmg;
        }
    }

    private void enemyDeath(string tag)
    {
        if (tag. Equals("FireProj"))
        {
            playDeathAnimation(fireColor);
        }
        if (tag.Equals("IceProj"))
        {
            playDeathAnimation(iceColor);
        }
        if (tag.Equals("ElectroProj"))
        {
            playDeathAnimation(electroColor);
        }
        
    }

    private void playDeathAnimation(Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EdgeColor", color);
    }
}
