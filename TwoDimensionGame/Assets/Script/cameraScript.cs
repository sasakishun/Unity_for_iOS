using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public GameObject target;
    public float damping = 0.1f;
    public Vector2 offset = Vector2.zero;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("rocket");
        damping = 5f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.GetComponent<Transform>().position;
        this.transform.position = Vector3.Lerp(transform.position,
            new Vector3(pos.x+offset.x, transform.position.y, transform.position.z), damping * Time.deltaTime);
        this.transform.position = new Vector3(transform.position.x, pos.y/4+offset.y, transform.position.z);

    }
}
