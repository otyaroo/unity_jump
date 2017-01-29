using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exclamation_block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("ブロックたたきました");
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
