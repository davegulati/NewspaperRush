using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;

    public float smoothSpeed = 10.0f;
    public Vector3 offset;

    private void Awake()
    {
        if (GameObject.Find("Player") == null)
        {
            Debug.LogError("No 'Player' gameobject found in the scene!");
        }
        else
        {
            player = GameObject.Find("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}
