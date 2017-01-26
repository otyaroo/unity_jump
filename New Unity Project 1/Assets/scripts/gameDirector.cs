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
}
