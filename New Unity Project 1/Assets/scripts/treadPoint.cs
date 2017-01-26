using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treadPoint : MonoBehaviour {
    // プレイヤーのグラウンドチェックコリジョンが入ってきたら
    // 踏んだとみなす。
    Collision2D playerGround;

	// Use this for initialization
	void Start () {
	    playerGround = GetComponent
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D()
    {

    }

}
