using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour {

    //private Rigidbody rb;
    //private float force = 150.0f;
    //private Vector3 constant = new Vector3(0, 0, 1);

    //private float speed = 0.05f;

    //private void Awake()
    //{
    //    if (GetComponent<Rigidbody>() == null)
    //    {
    //        Debug.LogError("No Rigidbody component found on player!");
    //    }
    //    else
    //    {
    //        rb = GetComponent<Rigidbody>();
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    //rb.AddForce(transform.forward * force);
    //    transform.Translate(transform.forward * speed);
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "LevelGround")
        {
            if (other.gameObject.tag != "Player")
            {
                Destroy(other.gameObject); 
            }
        }
    }
}
