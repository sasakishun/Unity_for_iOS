using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class RocketController : MonoBehaviour {
    static public Quaternion LookRotation2D(Vector2 _vec, Vector2 _up)
    {
        float tmpAng = (Mathf.Atan2(_up.y, _up.x) - Mathf.Atan2(_vec.y, _vec.x)) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(tmpAng, Vector3.forward);
    }
    public GameObject bulletPrefab;
    public float joystickPower = 0.01f;
    private RectTransform joyStickHandlePos;
    //private bool touched = false;
    private Vector2 pivot = Vector2.zero;
    JumpButton jumpScript;
    //タッチエフェクト用変数
    public GameObject particleObject;
    //ParticleSystem tapEffect;
    //public Camera _camera; // = GameObject.Find("MainCamera").GetComponent<Camera>();
    //public bool beamFlag = false;
    public GameObject BeamUI;
    // Use this for initialization
    void Start () {
        joyStickHandlePos = GameObject.Find("Handle").GetComponent<RectTransform>();
        jumpScript = GameObject.Find("Jump").GetComponent<JumpButton>();
        //tapEffect = particleObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
        //jumpしてない場合はjoystickからの操作を受け付ける
        if (!jumpScript.jumping)
        {
            this.GetComponent<Rigidbody2D>().velocity
            = new Vector2(joystickPower * joyStickHandlePos.localPosition.x, this.GetComponent<Rigidbody2D>().velocity.y);
        }
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Unity Editor called.");
            return;
        }
#else
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
            return;
        }
#endif
        /*
        //タッチ位置にエフェクト表示(うまく表示されないので保留0807)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ParticleStart");
            // マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 5);
            tapEffect.transform.position = pos;
            tapEffect.Emit(1);
            Debug.Log(pos);
            Debug.Log("ParticleEnd");
        }
        タッチ位置にエフェクト表示*/

        /*ジョイスティックを使うようになったので、タッチ位置に追従するメソッドは封印
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchを基にタッチ位置に向かって移動する処理をMoveで行う
            Move(touch);
        }
        else
        {
            this.touched = false;
        }*/

        //Keybourd input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        //マウスでクリックした方向にビームを発射する
        if (Input.GetMouseButtonDown(0))
        {
            beamLaunch(Input.mousePosition);
        }
        //Debug.Log(joyStickHandlePos.localPosition);
    }

    //mousePosに向かってビームを発射する
    public void beamLaunch(Vector3 mousePos)
    {
        mousePos = Input.mousePosition;
        mousePos.z = 0f;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        Quaternion rot = LookRotation2D(new Vector2(0, 1), objPos - transform.position);
        //ロケットの中心からビームを発射
        //Instantiate(bulletPrefab, transform.position, rot);

        //ロケットを中心とする半径1の円上から発射
        Vector3 targetVector = 3f * (objPos - transform.position).normalized;
        targetVector.x += transform.position.x;
        targetVector.y += transform.position.y;
        targetVector.z = 0f;
        Instantiate(bulletPrefab, targetVector, rot);
        Debug.Log("bullet instatiated");
        //Instantiate(bulletPrefab, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        //beamFlag = false;
        //BeamUI.SetActive(false);
    }

    public void beamLaunchbyJoystick(Vector3 objPos)
    {
        Quaternion rot = LookRotation2D(new Vector2(0, 1), objPos - transform.position);
        //ロケットの中心からビームを発射
        //Instantiate(bulletPrefab, transform.position, rot);

        //ロケットを中心とする半径1の円上から発射
        Vector3 targetVector = 3f * (objPos - transform.position).normalized;
        targetVector.x += transform.position.x;
        targetVector.y += transform.position.y;
        targetVector.z = 0f;
        Instantiate(bulletPrefab, targetVector, rot);
        Debug.Log("bullet instatiated");
        //Instantiate(bulletPrefab, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        //beamFlag = false;
        //BeamUI.SetActive(false);
    }

    void Move(Touch touch)
    {
        Vector3 target = touch.position;
        target = Camera.main.ScreenToWorldPoint(target);

        if (touch.phase == TouchPhase.Began && Math.Abs(target.x - transform.position.x) < 1.0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        transform.Translate(0.1f*(target.x-transform.position.x), 0, 0);
    }
    public void setPivot(Vector2 inputPivot)
    {
        pivot = inputPivot;
    }
    public void MoveByJoystick(Vector2 velocity)
    {
        this.transform.Translate(joystickPower * (velocity.x - pivot.x - transform.position.x), 0, 0);
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(joystickPower * (velocity.x-pivot.x), 0));
    }
    public void StopByJoystick()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}