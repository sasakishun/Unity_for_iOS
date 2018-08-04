using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    static public Quaternion LookRotation2D(Vector2 _vec, Vector2 _up)
    {
        float tmpAng = (Mathf.Atan2(_up.y, _up.x) - Mathf.Atan2(_vec.y, _vec.x)) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(tmpAng, Vector3.forward);
    }
    public GameObject bulletPrefab;
    public float timeOut = 3f;
    private float timeElapsed = 0f;
    public GameObject anchor;

    // Update is called once per frame
    void Update (){
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            Vector3 objPos = anchor.transform.position;
            Quaternion rot = LookRotation2D(new Vector2(0, 1), objPos - transform.position);
            transform.rotation = rot;
            //ロケットの中心からビームを発射
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rot);
            Destroy(bullet, 3f);
            //ロケットを中心とする半径1の円上から発射
            //Vector3 targetVector = 1f * (objPos - transform.position).normalized;
            //targetVector.x += transform.position.x;
            //targetVector.y += transform.position.y;
            //targetVector.z = 0f;
            //Instantiate(bulletPrefab, targetVector, rot);

            //Instantiate(bulletPrefab, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            timeElapsed = 0;
        }

    }
}
