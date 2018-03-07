using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

    private Transform player;
    private float generationDistance = 100.0f;

    public GameObject[] roads;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update () 
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= generationDistance)
        {
            GenerateRoad();
        }
	}

    public void GenerateRoad ()
    {
        // Generate random road tile.
        GameObject randomRoad = GetRandomRoad();
        GameObject generatedRoad = Instantiate(randomRoad, gameObject.transform.position, Quaternion.identity);

        // Move the generator along the Z axis.
        float generatedRoadWidth = GetRoadWidth(generatedRoad);
        Vector3 currentPosition = transform.position;
        currentPosition.z = currentPosition.z + generatedRoadWidth;
        transform.position = currentPosition;
    }

    private GameObject GetRandomRoad()
    {
        if (roads.Length > 1)
        {
            int index = Random.Range(0, roads.Length);
            if (roads[index] != null)
            {
                // Return random road.
                return roads[index];
            }
            else
            {
                // Return default road.
                return roads[0];
            }
        }
        else
        {
            // Return default road.
            return roads[0];
        }
    }

    private float GetRoadWidth (GameObject road)
    {
        // Return road width (Z axis).
        return road.GetComponent<Collider>().bounds.size.z;
    }
}
