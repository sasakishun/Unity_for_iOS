using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketUnderCollision : MonoBehaviour {
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Ground Collision");
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log("Ground Collision detection");
            GameObject.Find("Jump").GetComponent<JumpButton>().landing();
        }
    }
}
