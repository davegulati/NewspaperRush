using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

    private GameManager gameManager;

    private GameObject player;
    private Rigidbody rb;
    private float travelForceX = 300.0f;
    private float travelForceY = 300.0f;
    private int destroyTime = 4;

    private void Awake()
    {
        if (GameObject.Find("Managers").transform.Find("GameManager").GetComponent<GameManager>() == null)
        {
            Debug.LogError("No GameManager found! Are you missing the 'GameManager' gameobject or 'Game Manager' component?");
        }
        else
        {
            gameManager = GameObject.Find("Managers").transform.Find("GameManager").GetComponent<GameManager>();
        }

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
        rb.useGravity = true;
        rb.AddForce(Vector3.left * travelForceX);
        rb.AddForce(Vector3.up * travelForceY);
    }

    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mailbox")
        {
            Debug.Log("Newspaper landed in the mailbox!");
            gameManager.ResetTimeLimit();
        }

        if (collision.gameObject.tag == "House")
        {
            Debug.Log("Newspaper hit the house!");
        }

        Destroy(gameObject); 
    }
}
