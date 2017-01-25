using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveFooting : MonoBehaviour {


    Transform tf;
    float lateTime = 0.0f;
    bool right = true;
    
	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        // -----------------------------------------------------------------
        // 現状では、フレームごとに 0.1進む。
        // ゲームを動かす環境によって、動く足場の速度が変わってしまう
        // なので、フレームではなく時間で移動させる

        // 例えば 1s で 1.0f進ませるという形。
        // -------------------------------------------------------------------
        /*
        if (moveLengthRight > 0)
        {
            moveLengthRight -= 0.1f;
            Vector2 v2 = transform.position;
            v2.x += 0.1f;
            transform.position = v2;
        }

        else if (moveLengthLeft > 0)
        {
            moveLengthLeft -= 0.1f;
            Vector2 v2 = transform.position;
            v2.x -= 0.1f;
            transform.position = v2;
        }
        if(moveLengthLeft < 0)
        {
            moveLengthLeft = 4.0f;
            moveLengthRight = 4.0f;
        }*/
        // ---------------------------------------------------------------------------------------
        // 時間で動く足場ができました。
        // 4s で 4 動く足場
        // 
        // 4動いたら、反対に４動くようにする。

        // lateTimeにどんどん加算していき
        // 4 以上になったら 今度は 0 以下になるまで左に動くようにする
        // ----------------------------------------------------------------------------------------
        if (lateTime > 4)
            right = false;
        else if (lateTime < 0)
            right = true;

        if (right)
        {
            lateTime += Time.deltaTime * 2;
            tf.Translate(Vector3.right * Time.deltaTime * 2);
        } else
        {
            lateTime -= Time.deltaTime * 2;
            tf.Translate(Vector3.left * Time.deltaTime * 2);
        }

        // -----------------------------------------------------------------------------------------
        // 乗っているものも一緒に座標移動するようにする。
        // 今の状態だと、乗っているものは座標変わらず、足場だけ動いてる
        // なので乗ったものの座標も一緒に動かすようにしなければならない
        // -----------------------------------------------------------------------------------------

        // entercollision になったら物体のtransportを取得、
        // stay状態では 一緒に動かす
        // exit したら 破棄…できるのか？
        // otherっていうものもあったな…
        // あれでそういうことしなくてもよいのかも。

	}
    void OnCollisionStay(Collision other)
    {
        Debug.Log("OnCollisionStay が呼ばれました。");
        other.transform.Translate(Vector3.right * Time.deltaTime * 2);
    }
}
