using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

    private GameObject player;
    private Rigidbody rb;
    private float travelSpeed = 10.0f;
    private int destroyTime = 4;

    private void Awake()
    {
        if (GameObject.Find("Player") == null)
        {
            Debug.LogError("No 'Player' gameobject found in the scene!");
        }
        else
        {
            player = GameObject.Find("Player");
        }

        if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("No Rigidbody component found on the newspaper!");
        }
        else
        {
            rb = GetComponent<Rigidbody>();
        }

        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), player.GetComponent<SphereCollider>());
    }

    private void Start()
    {
        rb.useGravity = false;
    }

    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.left * travelSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mailbox")
        {
            Debug.Log("Newspaper landed in the mailbox!");
        }

        if (collision.gameObject.tag == "House")
        {
            Debug.Log("Newspaper hit the house!");
        }

        Destroy(gameObject); 
    }
}
