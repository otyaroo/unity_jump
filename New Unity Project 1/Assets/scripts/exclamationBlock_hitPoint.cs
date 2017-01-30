using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exclamationBlock_hitPoint : MonoBehaviour {
    GameObject exBlock;

	// Use this for initialization
	void Start () {
        exBlock = GameObject.Find("exclamationBlock");
	}


    // ---------------------------------------------------------------------------
    // ブロック下のトリガーボックスにプレイヤーが入ったら
    // 叩いたとみなし、ブロック側の Destroy関数を呼び出す。
    // ---------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("ブロックがたたかれました");
        if (coll.gameObject.tag == "Player")
            exBlock.GetComponent<exclamationBlock>().blockHitted();
    }
}
