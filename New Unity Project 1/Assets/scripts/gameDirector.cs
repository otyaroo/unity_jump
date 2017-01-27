using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDirector : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("kirby");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void enemyStep()
    {
        Debug.Log("gameDirector enemyStep()が呼ばれました");
        // 踏んだら、kirbyのスクリプト内の playerIsEnemyStep(); を呼び出す。
        this.player.GetComponent<kirby>().playerIsEnemyStep();
    }
}
