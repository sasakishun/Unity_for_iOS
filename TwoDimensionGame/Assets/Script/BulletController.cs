using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab

    public float timeOut = 3f;
    private float timeElapsed = 0f;
    private Rigidbody2D rb;
    public float power = 500f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * power);
    }
    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * 500f, ForceMode.Impulse);
        //transform.Translate(0, 0.2f, 0);
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            Destroy(gameObject);
        }
        //timeElapsed += 0f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // 衝突したときにスコアを更新する
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

        if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Ground")
        {
            // 爆発エフェクトを生成する
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 1.0f);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag != "Ground" && coll.gameObject.tag != "Player")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
