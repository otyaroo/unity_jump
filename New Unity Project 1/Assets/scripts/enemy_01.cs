using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour {
    Transform tf;
    bool moveRight = true;
    GameObject gameDirector;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
        gameDirector = GameObject.Find("gameDirector");
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

    
    // ----------------------------------------------------------------------------------
    // 何かにぶつかったら移動を反転する。
    // アイテムにぶつかっても反転しないようにするコードを後で記述。
    // ----------------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("enemy collision");
        //Debug.Log(moveRight);
        if(moveRight)
            moveRight = false;
        else
            moveRight = true;
    }

    // ----------------------------------------------------------------------------------
    // プレイヤーに踏まれたら
    // ----------------------------------------------------------------------------------
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("destroyが呼ばれました。");
            // プレイヤーに踏まれたことを
            // ゲーム管理スクリプト  gameDirector へ伝える
            gameDirector.GetComponent<gameDirector>().enemyStep();

            Destroy(gameObject, 0.2f);
            Destroy(GetComponent<enemy_01>());
        }
    }
}
