using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 気づいたことを書くだけ : MonoBehaviour {
//  クラス内のグローバル？変数はフレームをまたいで保存される。
//  update関数とかは毎回初期化されて始まる。

// ======================================================================================
/*
 * // unityEngineの中にComponentがあって、その中にgameObject と　getcomponent がある。
 * 
    unityEngine - Component - gameObject
                      - public method
                      
                      - GetComponent*/



// unityEngine - GameObject - GetComponent

//ex

// HingeJoint hinge = gameObject.GetComponent( typeof(HingeJoint) ) as HingeJoint


// =======================================================================================
/*
 *  // プレイヤーのグラウンドチェックコリジョンが入ってきたら
    // 踏んだとみなす。
    GameObject playerGround;            // UnityEngine.GameObject
    BoxCollider2D playerBoxCol2D;
	
    // Use this for initialization
	
    void Start () {
        playerGround = UnityEngine.GameObject.Find("kirby");
        playerBoxCol2D = playerGround.GetComponentInChildren(typeof(BoxCollider2D));
	}


    // playerGround.GetComponentInChildren は UnityEngine.Component型

    // なので、BoxCollider2D の playerBoxCol2Dに入れようとするとエラーになる。
    // では、別のゲームオブジェクトの要素を取得するにはどうすれば？
 */

 // ======================================================================================
}

// 上みたいにゲームオブジェクトのコンポーネントを最初から取得しなくても
// タグ付けしたものが入ってきたらみたいなことが下のコードでできるわけか。
/*
 *     void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", 10);
        
    }
}
*/

/*

public void playerIsEnemyStep()
    {
        Debug.Log("kirby playerIsEnemyStep関数がよばれました");
        this.rigid2D.AddRelativeForce(transform.up * this.jumpForce);
    }



    踏んだ後のジャンプの幅が不安定すぎる。
    小ジャンプ、  何も押さないで踏んだら
    大ジャンプ   ボタンを押した状態ならこれ
    すごいジャンプ　バグでしかない。

 */

// 落下中の速度に AddForceをするから小ジャンプになってるんかな？
// 