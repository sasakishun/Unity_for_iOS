using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour {
    public GameObject person;
    public bool jumping = false;
    public float jumpPower = 15f;
    public void OnClick()
    {
        Debug.Log("Button click!");
        if (!jumping) {
            person.GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpPower);
            jumping = true;
        }
    }
    public void landing()
    {
        jumping = false;
        person.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 0);
        Debug.Log("landing");
    }
    public void OnClick2()
    {
        Debug.Log("Button click!");
    }
}
