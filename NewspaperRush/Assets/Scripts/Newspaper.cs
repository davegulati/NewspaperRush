using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

    private GameManager gameManager;

    private GameObject player;
    private Rigidbody rb;

    // Left lane.
    private float travelForceX_l = 250.0f;
    private float travelForceY_l = 250.0f;

    // Middle lane.
    private float travelForceX_m = 350.0f;
    private float travelForceY_m = 350.0f;

    // Right lane.
    private float travelForceX_r = 400.0f;
    private float travelForceY_r = 400.0f;

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

        int lane = player.GetComponent<PlayerCharacterController>().GetCurrentLane();
        if (lane == -1)
        {
            rb.AddForce(Vector3.left * travelForceX_l);
            rb.AddForce(Vector3.up * travelForceY_l);
        }
        else if (lane == 0)
        {
            rb.AddForce(Vector3.left * travelForceX_m);
            rb.AddForce(Vector3.up * travelForceY_m);
        }
        else if (lane == 1)
        {
            rb.AddForce(Vector3.left * travelForceX_r);
            rb.AddForce(Vector3.up * travelForceY_r);
        }
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
