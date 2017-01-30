using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDirector : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("kirby");
	}
	
    // ------------------------------------------------------------------
    // 敵を踏んだ時に　敵側のスクリプトから呼ばれる関数
    // プレイヤー側の挙動をここで制御する。
    // -----------------------------------------------------------------

    public void enemyStep()
    {
        // 敵を踏んだことを kirbyに伝える。
        player.GetComponent<kirby>().playerIsEnemyStep();
    }

}
