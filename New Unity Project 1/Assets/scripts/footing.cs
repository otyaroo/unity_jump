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

    // ある一定の高さまで来たら足場を差し込む
    // のほうがいいのかも
    // 
    // 足場差し込む方式だと、誰かキャラクタが乗っているとほかのキャラクタは
    // 足場をすり抜けられないという状態になるのか。

    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 footingV2 = transform.position;
        Vector2 incommingV2 = other.attachedRigidbody.transform.position;
        Vector2 mixedV2;
        Vector2 incommingVelocity = other.attachedRigidbody.velocity;
        Vector2 mixedVelocity;

        mixedVelocity.x = 0.0f;
        mixedVelocity.y = -other.attachedRigidbody.velocity.y;

        mixedV2.x = incommingV2.x;
        mixedV2.y = footingV2.y + 1;
        other.attachedRigidbody.AddForce(incommingVelocity);
        //other.attachedRigidbody.MovePosition(mixedV2);

       // other.attachedRigidbody.AddForce(transform.up * 0.01f);
    }
}
