using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveFooting : MonoBehaviour {

    Transform tf;

    float moveLengthRight = 4.0f;
    float moveLengthLeft = 4.0f;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
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
        }
        Debug.Log(moveLengthRight);
        Debug.Log(moveLengthLeft);
	}
}
