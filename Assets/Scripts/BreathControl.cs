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

    [SerializeField]
    private Transform _fuelScale;
    [SerializeField]
    private float _fuelPerSec = 30f;
    [SerializeField]
    private float _fuelRefillPerSec = 10f;
    private float _maxFuel = 100f;
    private float _currentFuel = 100f;
    private bool _isBreathing = false;
    [SerializeField]
    private float _lockTime=0.5f;
    private float _clock=0f;
    [SerializeField]
    private AudioSource _flameSource;
    [SerializeField]
    private AudioSource _iceSource;
    [SerializeField]
    private AudioSource _electroSource;

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
        _isBreathing = false;
        _fuelScale.localScale = new Vector3(_currentFuel / 100f,_fuelScale.localScale.y,_fuelScale.localScale.z);

        InputButtonUp();
        _clock += Time.deltaTime;
        if (_clock > _lockTime)
        {
            if (_currentFuel > 0)
            {
                InputButtonDown();
                InputButton();
                InputFuelButton();

            }
            else
            {
                _clock = 0f;
            }
        }
    
        if (!_isBreathing)
        {
            _currentFuel = Mathf.Min(_maxFuel, _currentFuel + Time.deltaTime*_fuelRefillPerSec);
        }
    }

    private void InputButtonUp()
    {
        if (_currentFuel == 0 || Input.GetMouseButtonUp(0))
        {
            _flameSource.Stop();
            fireBreath.Stop();
        }

        if (_currentFuel == 0 || Input.GetMouseButtonUp(1))
        {
            _iceSource.Stop();
            iceBreath.Stop();
        }


        if (_currentFuel == 0 || Input.GetMouseButtonUp(2))
        {
            _electroSource.Stop();
            electroBreath.Stop();
        }
    }

    private void InputButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireBreath.Play();
            SpawnProjectile(fireProjectile, fireStart);
        }


        if (Input.GetMouseButtonDown(1))
        {
            iceBreath.Play();
            SpawnProjectile(iceProjectile, iceStart);
        }


        if (Input.GetMouseButtonDown(2))
        {
            electroBreath.Play();
            SpawnProjectile(electroProjectile, electroStart);
        }
    }

    private void InputButton()
    {
        if (Input.GetMouseButton(0) && Time.time >= _timeToFireFire)
        {
            if (!_flameSource.isPlaying)
            {
                _flameSource.Play();
            }
            fireBreath.Play();
            _timeToFireFire = Time.time + 1 / fireProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(fireProjectile, fireStart);
        }
        if (Input.GetMouseButton(1) && Time.time >= _timeToFireIce)
        {
            if (!_iceSource.isPlaying)
            {
                _iceSource.Play();
            }
            iceBreath.Play();
            _timeToFireIce = Time.time + 1 / iceProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(iceProjectile, iceStart);
        }
        if (Input.GetMouseButton(2) && Time.time >= _timeToFireElectro)
        {
            if (!_electroSource.isPlaying)
            {
                _electroSource.Play();
            }
            electroBreath.Play();
            _timeToFireElectro = Time.time + 1 / electroProjectile.GetComponent<ProjectileMovement>().fireRate;
            SpawnProjectile(electroProjectile, electroStart);
        }
    }

    private void InputFuelButton()
    {
        if (Input.GetMouseButton(0))
        {
            _isBreathing = true;
            ReduceFuel();
        }
        if (Input.GetMouseButton(1))
        {
            _isBreathing = true;
            ReduceFuel();
        }
        if (Input.GetMouseButton(2))
        {
            _isBreathing = true;
            ReduceFuel();
        }
    }

    private void ReduceFuel()
    {
        _currentFuel = Mathf.Max(0,_currentFuel - Time.deltaTime*_fuelPerSec);
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
