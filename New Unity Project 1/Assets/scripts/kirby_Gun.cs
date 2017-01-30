using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    GameObject player;
    GameObject blueBullet;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("kirby");
        blueBullet = new GameObject("blueBullet");
        blueBullet.AddComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            player.GetComponent<kirby>().gunMode = true;
    }

    public void shoot()
    {

    }
}