using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullutController : MonoBehaviour {
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    //public float timeOut = 3f;
    //private float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.2f, 0);
        //timeElapsed += Time.deltaTime;
        //if (timeElapsed >= timeOut)
        //{
            //Destroy(gameObject);
        //}
        //timeElapsed += 0f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            // 爆発エフェクトを生成する
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 1.0f);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player")
        {
            // 爆発エフェクトを生成する
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 1.0f);
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
