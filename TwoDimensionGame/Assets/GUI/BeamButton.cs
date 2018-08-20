using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamButton : MonoBehaviour {
    public RocketController rocket;
    public GameObject BeamUI;
    void Start()
    {
        rocket = GameObject.Find("rocket").GetComponent<RocketController>();
        //BeamUI = GameObject.Find("BeamJoystick").GetComponent<GameObject>();
    }
    public void OnClick()
    {
        Debug.Log("Beam click!");
        //rocket.beamFlag = true;
        if (GameObject.Find("BeamJoystick")==null){
            BeamUI.SetActive(true);
        }
        else
        {
            BeamUI.SetActive(false);
        }
    }
}
