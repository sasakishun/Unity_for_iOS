using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BeamJoyStick : Joystick
{
    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();
    private RocketController rocketScript;
    Vector2 targetDir = Vector2.zero;
    
    void Start()
    {
        //joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, GetComponent<RectTransform>().anchoredPosition);
        //Debug.Log(joystickPosition);
        rocketScript = GameObject.Find("rocket").GetComponent<RocketController>();
        //rocketScript.setPivot(joystickPosition);
    }

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

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        rocketScript.beamLaunch(targetDir);
    }
}
