using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BreathControl : MonoBehaviour
{
    public VisualEffect breath;
    
    void Start()
    {
        breath.Stop();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            breath.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            breath.Stop();
        }
    }
}
