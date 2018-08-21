using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BeamJoyStick : Joystick
{
    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();
    private RocketController rocketScript;
    public Vector2 targetDir = Vector2.zero;
    public GameObject rocket;
    public Camera mainCamera;

    void Start()
    {
        //joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, GetComponent<RectTransform>().anchoredPosition);
        rocketScript = GameObject.Find("rocket").GetComponent<RocketController>();
        //rocketScript.setPivot(joystickPosition);
        rocket = GameObject.Find("rocket");
        //mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    //void Update()
    //{
        //this.GetComponent<Transform>().position = mainCamera.WorldToScreenPoint(rocket.GetComponent<Transform>().position);
        //Debug.Log(string .Format("BeamJoy position: {0}", mainCamera.WorldToScreenPoint(rocket.GetComponent<Transform>().position).x));
    //}

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
       　
        //ジョイスティックの傾きと反対の方向を、ビーム発射方角とする
        targetDir = -direction;
        //rocketScript.MoveByJoystick(eventData.position);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    //ジョイスティックを離した時に呼ばれる
    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        rocketScript.beamLaunchbyJoystick(new Vector3 (targetDir.x+rocket.GetComponent<Transform>().position.x, targetDir.y + rocket.GetComponent<Transform>().position.y, 0f));
        Debug.Log(targetDir);
    }
}
