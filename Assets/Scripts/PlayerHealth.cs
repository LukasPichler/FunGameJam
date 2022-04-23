using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private int lifes=3;

    [SerializeField]
    private GameObject deathScreen;

    [SerializeField]
    private float slowDownTime = 0.1f;

    private float normalTimeScale;

    private void Awake()
    {
        normalTimeScale = Time.timeScale; 
    }

    public void ReduceLifeBy(int reduction)
    {
        lifes -= reduction;
        if (lifes < 0)
        {
            lifes = 0;
            deathScreen.SetActive(true);
            Time.timeScale *= slowDownTime;
        }
        ChangeLife();
    }


    private void ChangeLife()
    {
        text.text = lifes + "X";
    }
}
