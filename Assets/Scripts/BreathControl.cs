using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BreathControl : MonoBehaviour
{
    public VisualEffect fireBreath;
    public VisualEffect iceBreath;
    public VisualEffect electroBreath;

    public GameObject fireProjectile;
    public GameObject iceProjectile;
    public GameObject electroProjectile;

    public GameObject fireStart;
    public GameObject iceStart;
    public GameObject electroStart;

    private float _timeToFireFire = 0;
    private float _timeToFireIce = 0;
    private float _timeToFireElectro = 0;
    void Start()
    {
        fireBreath.Stop();
        iceBreath.Stop();
        electroBreath.Stop();
    }


    void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            fireBreath.Play();
            SpawnProjectile(fireProjectile,fireStart);
        }
        if (Input.GetMouseButtonUp(0))
        {
            fireBreath.Stop();
        }
        
        
        if (Input.GetMouseButtonDown(1))
        {
            iceBreath.Play();
            SpawnProjectile(iceProjectile,iceStart);
        }
        if (Input.GetMouseButtonUp(1))
        {
            iceBreath.Stop();
        }
        
        
        if (Input.GetMouseButtonDown(2))
        {
            electroBreath.Play();
            SpawnProjectile(electroProjectile,electroStart);
        }
        if (Input.GetMouseButtonUp(2))
        {
            electroBreath.Stop();
        }
        
        if (Input.GetMouseButton(0)&&Time.time>=_timeToFireFire)
        {
            _timeToFireFire = Time.time + 1 / fireProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(fireProjectile,fireStart);
        }
        if (Input.GetMouseButton(1)&&Time.time>=_timeToFireIce)
        {
            _timeToFireIce = Time.time + 1 / iceProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(iceProjectile,iceStart);
        }
        if (Input.GetMouseButton(2)&&Time.time>=_timeToFireElectro)
        {
            _timeToFireElectro = Time.time + 1 / electroProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(electroProjectile,electroStart);
        }
    }


    
    
    public void SpawnProjectile(GameObject projectile, GameObject startPoint)
    {
        GameObject proj;
        if (startPoint != null)
        {
            proj = Instantiate(projectile, startPoint.transform.position,startPoint.transform.rotation);
            proj.transform.localPosition = startPoint.transform.position;
            proj.transform.localRotation = startPoint.transform.rotation;
        }
        else
        {
            Debug.Log("Startpoint of Projectile not set!");
        }
    }


}
