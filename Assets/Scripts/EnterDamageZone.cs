using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDamageZone : MonoBehaviour
{
    public string EnemyTag = "Enemy";

    [SerializeField]
    private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == EnemyTag)
        {
            Destroy(other.gameObject);
            playerHealth.ReduceLifeBy(1);
        }
    }
}