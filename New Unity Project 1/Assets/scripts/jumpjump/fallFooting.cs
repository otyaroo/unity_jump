using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallFooting : MonoBehaviour {

    Rigidbody2D rigid2D;
    Transform tf;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        tf.Translate(Vector3.down * Time.deltaTime * 0.8f);
	}


    void OnCollisionStay2D(Collision2D other)
    {
        //Debug.Log("足場, OnCollisionStay2D in");
        other.transform.Translate(Vector3.down * Time.deltaTime);
       

    }
}

