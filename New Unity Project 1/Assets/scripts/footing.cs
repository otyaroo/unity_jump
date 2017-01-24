using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footing : MonoBehaviour {

    Rigidbody2D rigid2D;

    // -------------------------------------------------------------------
    // よくわかってないが、
    // 上ベクトルの動きの時は貫通し、
    // したベクトルの動きの時は反発する？
    // みたいな動きをする足場を作れば、下からは通り抜けられる足場ができるかも
    // -------------------------------------------------------------------
    // ただし、この条件を足場につけるのか、それとも
    // それぞれに…
    // ああ、でもアイテムとかもこれに該当するから、足場につけてあげたほうが良いのかも。
    // -------------------------------------------------------------------
	// Use this for initialization
	void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 足場に入ってきた物体を足場の上に移動させ続ける
    // X座標はいじらない。
    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 footingV2 = transform.position;
        Vector2 incommingV2 = other.attachedRigidbody.transform.position;
        Vector2 mixedV2;
        mixedV2.x = incommingV2.x;
        mixedV2.y = footingV2.y + 1;
        other.attachedRigidbody.MovePosition(mixedV2);
    }
}
