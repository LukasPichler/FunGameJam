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
    private MoreMountains.Feedbacks.MMTimeManager _timeManager;

    [SerializeField]
    private float slowDownTime = 0.1f;

    private bool dead = false;

    [SerializeField]
    private MoreMountains.Feedbacks.MMFeedbacks damageFeedback;

    private void Update()
    {
        if (dead)
        {
            _timeManager.SetTimescaleTo(slowDownTime);
        }
    }

    public void ReduceLifeBy(int reduction)
    {
        if (!dead && lifes > 0)
        {
            damageFeedback?.PlayFeedbacks();
        }
        lifes -= reduction;
        if (!dead && lifes < 0)
        {
            lifes = 0;
            deathScreen.SetActive(true);
            dead = true;
        }
        ChangeLife();
    }


    private void ChangeLife()
    {
        text.text = lifes + "X";
    }
}
