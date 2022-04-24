using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Tutroial : MonoBehaviour
{
    private int _step=0;

    [SerializeField]
    private MoreMountains.Feedbacks.MMFeedbacks _switchTextFeedback;

    [SerializeField]
    private TextMeshProUGUI _textMesh;

    [SerializeField]
    private string _step1Text;
    [SerializeField]
    private MoreMountains.Feedbacks.MMFeedbacks _barFeedback;




    [SerializeField]
    private string _step1P1Text;
    [SerializeField]
    private string _step2Text;
    [SerializeField]
    private GameObject enemie;
    [SerializeField]
    private MoreMountains.Feedbacks.MMFeedbacks _healBarFeedback;[SerializeField]
    private GameObject enemi1;
    [SerializeField]
    private GameObject enemi2;
    [SerializeField]
    private GameObject enemi3;


    [SerializeField]
    private string _finalStepText;
    [SerializeField]
    private float _time = 2f;
    private float _clock = 0f;
    [SerializeField]
    private MoreMountains.TopDownEngine.StartScreen _sceneSwap;
    // Start is called before the first frame update
    void Start()
    {
        enemie.GetComponentInChildren<Animator>().SetBool("Tutrial",true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_step){
            case 0:
                Step0();
                break;
            case 1:
                Step1();
                break;
            case 2:
                Step2();
                break;

            default:
                FinalStep();
                break;
        }
    }

   

    private void Step0()
    {
        if ( 0.5f <= Mathf.Abs(Input.GetAxis("Horizontal")) || 0.5f <= Mathf.Abs(Input.GetAxis("Vertical")))
        {
            NextStep();
            _textMesh.text = _step1Text;
            _barFeedback.PlayFeedbacks();
        }
    }

    private void Step1()
    {
        if (enemi1 == null && enemi2 == null && enemi3 == null)
        {

            _textMesh.text = _step2Text;
            NextStep();
        }
        if (enemie == null && (!enemi1.activeInHierarchy && !enemi2.activeInHierarchy && !enemi3.activeInHierarchy))
        {
            _switchTextFeedback.PlayFeedbacks();
            _textMesh.text = _step1P1Text;
            _healBarFeedback.PlayFeedbacks();
            enemi1.SetActive(true);
            enemi2.SetActive(true);
            enemi3.SetActive(true);
            enemi1.GetComponentInChildren<Animator>().SetBool("Tutrial", true);
            enemi2.GetComponentInChildren<Animator>().SetBool("Tutrial", true);
            enemi3.GetComponentInChildren<Animator>().SetBool("Tutrial", true);

        }
    }

    private void Step2()
    {
        _clock += Time.deltaTime;
        if (_clock>_time)
        {
            NextStep();
            _textMesh.text = _finalStepText;
        }
    }

    private void FinalStep()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sceneSwap.ButtonPressed();
        }
    }
    private void NextStep()
    {
        _step++;
        _switchTextFeedback.PlayFeedbacks();
    }
}
