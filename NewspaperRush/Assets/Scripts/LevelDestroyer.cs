using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour {

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
