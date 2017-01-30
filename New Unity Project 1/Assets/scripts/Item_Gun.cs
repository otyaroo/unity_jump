using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Gun : MonoBehaviour {
    // ------------------------------------------------------------
    // 地面につくまでは、Rigidbody2Dを Dynamicで動作
    // 地面についた瞬間に Staticに変更
    // BoxCollider2D は Triggerモードへ移行。
    // 
    // プレイヤーがOnTrrigerEnter2D したら、
    // プレイヤーに銃撃ができるように kirby - gunMode を trueにする。
    // --------------------------------------------------------------

    Rigidbody2D rigid2D;
    BoxCollider2D boxColl2D;

	// Use this for initialization
	void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
        boxColl2D = GetComponent<BoxCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面にぶつかったら 物理挙動を切る。

        rigid2D.simulated = false;

        // 地面にぶつかったら、トリガーモードへ。
        boxColl2D.isTrigger = true;
    }
}
