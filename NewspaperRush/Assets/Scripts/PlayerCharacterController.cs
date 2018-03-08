using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    public float playerMoveForwardSpeed = 5.0f;
    private Rigidbody rb;
    private ConstantForce cF;
    private float jumpForce = 400.0f;

    private int currentLane;
    private float moveLeftBy = 4.5f;
    private float moveRightBy = 4.5f;

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

    private void Start()
    {
        GetCurrentLane();
    }

    private void Update()
    {
        if (Input.GetButtonDown("MoveLeft"))
        {
            MoveLeft();
        }
        else if (Input.GetButtonDown("MoveRight"))
        {
            MoveRight();
        }

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

    public int GetCurrentLane ()
    {
        UpdateCurrentLane();
        return currentLane;
    }

    private void UpdateCurrentLane()
    {
        if (transform.position.x < 0)
        {
            currentLane = -1;
        }
        else if (transform.position.x == 0)
        {
            currentLane = 0;
        }
        else
        {
            currentLane = 1;
        }
    }

    private void MoveLeft ()
    {
        if (GetCurrentLane() == -1)
        {
            return;
        }
        else
        {
            // Move left 1 lane.
            Vector3 currentPosition = transform.position;
            currentPosition.x = currentPosition.x - moveLeftBy;
            transform.position = currentPosition;
        }
    }

    private void MoveRight ()
    {
        if (GetCurrentLane() == 1)
        {
            return;
        }
        else
        {
            // Move right 1 lane.
            Vector3 currentPosition = transform.position;
            currentPosition.x = currentPosition.x + moveRightBy;
            transform.position = currentPosition;
        }
    }

    private void ThrowNewspaper ()
    {
        Instantiate(newspaper, transform.position, transform.rotation);
    }

    public float ReturnPlayerSpeed ()
    {
        return playerMoveForwardSpeed;
    }
}
