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
    int jumpFrame = 0;
    float speedLimit;

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

        // ダッシュボタンを押していると最高速リミットが上がる
        // -----------------------------------------------------------------

        if (Input.GetKey(KeyCode.C))
            speedLimit = 8.0f;
        else
            speedLimit = 5.0f;

        // -----------------------------------------------------------------
        if (absVelocityX < speedLimit)
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
            this.rigid2D.AddForce(transform.right * 5.0f);

        // 右方向にスピードオーバーしていたら
        else if (this.rigid2D.velocity.x > 0)
            this.rigid2D.AddForce(transform.right * -5.0f);
        
	}
    // ------------------------------------------------------------------
    // ジャンプの条件式
    // 
    // 壁にあたっている状態でもジャンプできないようになった。
    // Triggerモードになっているのが GroundCheckだけだからかも。
    // あとは、キャラクタのコライダーよりも GroundCheckの判定が小さいのも

    // すごいジャンプをしてしまうのは、ジャンプする前に２回ジャンプの関数に入ってるから。
    // 関数に入ったあと、0.1s間ジャンプできないようにする…のではどうだろう？
    // ただ、ジャンプしてなくてもこれは動くんだよなぁ
    // ------------------------------------------------------------------

    void OnTriggerStay2D(Collider2D other)
    {
        
        //Debug.Log("Enter OnTriggerStay method");
        // ジャンプしてから 3フレームは再ジャンプ不可
        if (jumpFrame < Time.frameCount)
        {
            if (Input.GetKey(KeyCode.X))
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                jumpFrame = Time.frameCount + 3;
            }

            if (Input.GetKey(KeyCode.Z))
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce * 0.8f);
                jumpFrame = Time.frameCount + 3;
            }
        }
    }
   
}



