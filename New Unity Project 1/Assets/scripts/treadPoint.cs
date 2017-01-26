using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treadPoint : MonoBehaviour {
    // プレイヤーのグラウンドチェックコリジョンが入ってきたら
    // 踏んだとみなす。
    //GameObject enemyParent;            // UnityEngine.GameObject

	// Use this for initialization
	void Start () {
      //  enemyParent = GetComponentInParent(typeof(gameObject))as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("Enemy_01"));
        }

        Debug.Log("destroyが呼ばれました。");
    }

}
