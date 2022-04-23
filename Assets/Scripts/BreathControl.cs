using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BreathControl : MonoBehaviour
{
    public VisualEffect fireBreath;
    public VisualEffect iceBreath;
    public VisualEffect electroBreath;
    
    void Start()
    {
        fireBreath.Stop();
        iceBreath.Stop();
        electroBreath.Stop();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireBreath.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            fireBreath.Stop();
        }
        if (Input.GetMouseButtonDown(1))
        {
            iceBreath.Play();
        }

        if (Input.GetMouseButtonUp(1))
        {
            iceBreath.Stop();
        }
        if (Input.GetMouseButtonDown(2))
        {
            electroBreath.Play();
        }

        if (Input.GetMouseButtonUp(2))
        {
            electroBreath.Stop();
        }
    }
}
