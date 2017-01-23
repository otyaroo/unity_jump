using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class kirby : MonoBehaviour {

// ====================================================================  
//    変数宣言
// ====================================================================

    Rigidbody2D rigid2D;
    float jumpForce = 400.0f;
    float walkForce = 15.0f;

// =====================================================================
	// Use this for initialization
// =====================================================================
	void Start () {
       
        // このスクリプトを適用する ゲームオブジェクトのRigitbody2Dの状態を操作する。

        this.rigid2D = GetComponent<Rigidbody2D>();
	}
// =====================================================================
	// Update is called once per frame
// ====================================================================
	void Update () {

        float absVelocityX = Mathf.Abs(this.rigid2D.velocity.x);
        float absVelocityY = Mathf.Abs(this.rigid2D.velocity.y);

        if (Input.GetKey(KeyCode.X))
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        if (Input.GetKey(KeyCode.Z))
            this.rigid2D.AddForce(transform.up * this.jumpForce * 0.8f);


        // ==================================================================
        // 左右移動の条件式
        //
        // 絶対値で速度オーバーしない限り、
        // 下の減速式には入らないはず。
        // ==================================================================
        if (absVelocityX < 5.0f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                this.rigid2D.AddForce(transform.right * walkForce);
            if (Input.GetKey(KeyCode.LeftArrow))
                this.rigid2D.AddForce(transform.right * -walkForce);
        }
        // 左方向にスピードオーバーしていたら
        else if (this.rigid2D.velocity.x < 0)
            this.rigid2D.AddForce(transform.right * 1.0f);

        // 右方向にスピードオーバーしていたら
        else if (this.rigid2D.velocity.x > 0)
            this.rigid2D.AddForce(transform.right * -1.0f);
            




        Debug.Log(rigid2D.velocity);

	}
}



