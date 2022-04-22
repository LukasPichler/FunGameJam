using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHandeling : MonoBehaviour
{
    public class Feder
    {
        public Feder(bool player,GameObject point1, bool isFixed1, Rigidbody rigid1, GameObject point2, bool isFixed2, Rigidbody rigid2, float federkonstante, float federLength)
        {
            Player = player;
            Point1 = point1;
            Point2 = point2;
            IsFixed1 = isFixed1;
            IsFixed2 = isFixed2;
            Rigid1 = rigid1;
            Rigid2 = rigid2;
            Federkonstante = federkonstante;
            FederLength = federLength;
        }

        public bool Player;
        public GameObject Point1;
        public bool IsFixed1;
        public Rigidbody Rigid1;
        public GameObject Point2;
        public bool IsFixed2;
        public Rigidbody Rigid2;
        public float Federkonstante;
        public float FederLength;
    }


    private LineRenderer lineRenderer;

    [SerializeField]
    private float _untereGrenze = -0.4f;
    [SerializeField]
    private float _obereGrenze = -2.5f;

    [SerializeField]
    private int _numberOfPoints=2;

    [SerializeField]
    private GameObject _pole;
    
    [SerializeField]
    private GameObject _dog;

    [SerializeField]
    private float _federkonstante=1000;

    [SerializeField]
    private float _federLength;

    [SerializeField]
    private GameObject _chainLinkPrefab;

    private GameObject[] _points;

    private Feder[] _rope;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = _numberOfPoints;
    }

    private void Start()
    {
        _points = new GameObject[_numberOfPoints];
        _rope = new Feder[_numberOfPoints - 1];

        CreatPoints();

        CreateFedern();
    }

    private void Update()
    {
        for(int i=0; i<_points.Length; i++)
        {
            lineRenderer.SetPosition(i, _points[i].transform.position);
        }
        
    }


    private void FixedUpdate()
    {

        FederBerechnung();
    }


    private void FederBerechnung()
    {
        for (int i = 0; i < _rope.Length; i++)
        {
            Feder feder = _rope[i];
            Vector3 distance = feder.Point1.transform.position - feder.Point2.transform.position;
            float relativeDistance = (feder.FederLength - distance.magnitude);
            if (relativeDistance < 0f)
            {

                Vector3 force = feder.Federkonstante * relativeDistance * distance.normalized;

                if (!feder.IsFixed1)
                {

                    feder.Rigid1.velocity += (Time.deltaTime * Time.deltaTime * force);
                }
                if (!feder.IsFixed2)
                {
                    if (feder.Player)
                    {
                        if (!(relativeDistance < _untereGrenze && relativeDistance > _obereGrenze))
                        {
                            force = Vector3.zero;
                        }
                    }
                    feder.Rigid2.velocity += (Time.deltaTime * Time.deltaTime * -force);
                }
            }

        }
    }

    private void CreateFedern()
    {
        for (int i = 0; i < _numberOfPoints - 1; i++)
        {
            float distance = _federLength/_numberOfPoints;
            Feder newFeder = new Feder(i==_numberOfPoints-2,_points[i], i == 0, _points[i].GetComponent<Rigidbody>(), _points[i+1], false, _points[i+1].GetComponent<Rigidbody>(), _federkonstante,distance);
            _rope[i] = newFeder;
        }
    }

    private void CreatPoints()
    {
        _points[0] = _pole;
        _points[_numberOfPoints - 1] = _dog;

        for (int i = 1; i < _points.Length - 1; i++)
        {
            GameObject newObject = Instantiate(_chainLinkPrefab);
            newObject.transform.position = Vector3.Lerp(_pole.transform.position, _dog.transform.position, i / ((float)_numberOfPoints - 1));
            newObject.transform.parent = transform;
            _points[i] = newObject;
        }
    }
    
}
