using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    public float playerMoveForwardSpeed = 5.0f;
    private Rigidbody rb;
    private ConstantForce cF;
    private float jumpForce = 400.0f;

    public GameObject newspaper;

    private void Awake()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("No Rigidbody component found on player!");
        }
        else
        {
            rb = GetComponent<Rigidbody>();
        }

        if (GetComponent<ConstantForce>() == null)
        {
            Debug.LogError("No Constant Force component found on player!");
        }
        else
        {
            cF = GetComponent<ConstantForce>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ThrowNewspaper();
        }
    }

    private void FixedUpdate()
    {
        cF.force = Vector3.forward * playerMoveForwardSpeed;
    }

    private void ThrowNewspaper()
    {
        Instantiate(newspaper, transform.position, transform.rotation);
    }
}
