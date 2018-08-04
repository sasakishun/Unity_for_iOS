using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour {
    public GameObject person;
    bool jumping = false;
    
    public void OnClick()
    {
        Debug.Log("Button click!");
        if (!jumping) {
            person.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
            jumping = true;
        }
    }
    public void landing()
    {
        jumping = false;
        Debug.Log("landing");
    }
    public void OnClick2()
    {
        Debug.Log("Button click!");
    }
}
