using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemieMoveMent : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private Transform _path;

    private int _currentPoint = 0;

    private Rigidbody _rb;

    private List<Transform> _pathPoints = new List<Transform>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform point in _path)
        {
            _pathPoints.Add(point.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 distance =  _pathPoints[_currentPoint].position- transform.position;
        distance = new Vector3(distance.x, 0, distance.z);
        Quaternion rotTarget = Quaternion.LookRotation(distance);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, _rotationSpeed);
        _rb.velocity = transform.forward * _speed;
        if (distance.magnitude < 0.5f)
        {
            _currentPoint++;
        }
    }

  
}
