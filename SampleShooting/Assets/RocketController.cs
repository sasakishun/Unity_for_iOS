using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketController : MonoBehaviour {
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
		
	}
    private bool touched = false;

	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // touchを基にタッチ位置に向かって移動する処理をMoveで行う
            Move(touch);
        }
        else
        {
            this.touched = false;
        }

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
}