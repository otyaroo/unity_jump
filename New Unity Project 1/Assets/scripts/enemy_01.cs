using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour {
    Transform tf;
    bool moveRight = true;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        // とりあえず、右に動き続ける。
        if (moveRight)
            tf.Translate(Vector3.right * Time.deltaTime);
        else
            tf.Translate(Vector3.left * Time.deltaTime);
        // 敵を押すことができるなぁ。
        // 被弾したときに、kinematicにしても壁を貫通してしまうしなぁ。
        // staticにすると、地面の端で食らったときに、敵が浮いている状態になってしまう。
        // rigidbody2D が押すことを可能にしてしまってるんだよなぁ。
        // でも入れないと、重力が発生しなくなってしまう。

        // プレイヤー側のrigidbody2Dをなくすは、ダメだな。
        // 
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("enemy collision");
        Debug.Log(moveRight);
        if(moveRight)
            moveRight = false;
        else
            moveRight = true;
    }
}
