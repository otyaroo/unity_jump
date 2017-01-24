using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class kirby : MonoBehaviour {

// ====================================================================  
//    変数宣言
// ====================================================================

    Rigidbody2D rigid2D;                       // このスクリプトを充てるゲームオブジェクトの Rigidbody2Dコンポーネントを操作する。
    GameObject playerGroundCheck;
    Collider2D col2D;
    Transform tf;
    float jumpForce = 500.0f;
    float walkForce = 15.0f;

// =====================================================================
	// Use this for initialization
// =====================================================================
	void Start () {

        // このスクリプトを適用する ゲームオブジェクトのRigitbody2Dの状態を操作する。
        this.playerGroundCheck = GameObject.Find("playerGroundCheck");
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.col2D = gameObject.GetComponentInChildren<BoxCollider2D>();
        this.tf = GetComponent<Transform>();
	}
// =====================================================================
	// Update is called once per frame
// ====================================================================
	void Update () {

        float absVelocityX = Mathf.Abs(this.rigid2D.velocity.x);
        float absVelocityY = Mathf.Abs(this.rigid2D.velocity.y);
        


        // ------------------------------------------------------------------
        // 左右移動の条件式
        //
        // 絶対値で速度オーバーしない限り、
        // 下の減速式には入らないはず。
        // ------------------------------------------------------------------
        if (absVelocityX < 5.0f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.rigid2D.AddForce(transform.right * walkForce);
                tf.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.rigid2D.AddForce(transform.right * -walkForce);
                tf.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
        }
        // 左方向にスピードオーバーしていたら
        else if (this.rigid2D.velocity.x < 0)
            this.rigid2D.AddForce(transform.right * 1.0f);

        // 右方向にスピードオーバーしていたら
        else if (this.rigid2D.velocity.x > 0)
            this.rigid2D.AddForce(transform.right * -1.0f);

        Debug.Log(tf.localRotation);
        
	}
    // ------------------------------------------------------------------
    // ジャンプの条件式
    // 
    // 壁にあたっている状態でもジャンプできないようになった。
    // Triggerモードになっているのが GroundCheckだけだからかも。
    // あとは、キャラクタのコライダーよりも GroundCheckの判定が小さいのも
    // ------------------------------------------------------------------

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("床に触れてます");
        if (Input.GetKey(KeyCode.X))
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        if (Input.GetKey(KeyCode.Z))
            this.rigid2D.AddForce(transform.up * this.jumpForce * 0.8f);
    }
   
}



