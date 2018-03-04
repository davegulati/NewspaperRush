using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    
    //public float speed = 3.72f;
    //private Vector3 offset = new Vector3(0, 0, 10);

    private bool generateLevel = true;
    private float generateRoadDelay = 3.5f;

    public GameObject road;

	//private void Awake () 
 //   {
 //       transform.position = offset;
	//}

    private void Start()
    {
        StartCoroutine(GenerateRoad());
    }

 //   private void FixedUpdate () 
 //   {
 //       transform.Translate(Vector3.forward * Time.deltaTime * speed);
	//}

    IEnumerator GenerateRoad ()
    {
        while (generateLevel)
        {
            Instantiate(road, transform.Find("RoadGenerationPoint").transform.position, Quaternion.identity);
            yield return new WaitForSeconds(generateRoadDelay);
        }
    }
}
