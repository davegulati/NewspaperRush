using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour
{

    private Transform player;
    private float generationDistance = 100.0f;

    public GameObject[] houses;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= generationDistance)
        {
            GenerateHouse();
        }
    }

    public void GenerateHouse()
    {
        // Generate random house tile.
        GameObject randomHouse = GetRandomHouse();
        GameObject generatedHouse = Instantiate(randomHouse, gameObject.transform.position, Quaternion.identity);

        // Move the generator along the Z axis.
        float generatedHouseWidth = GetHouseWidth(generatedHouse);
        Vector3 currentPosition = transform.position;
        currentPosition.z = currentPosition.z + generatedHouseWidth;
        transform.position = currentPosition;
    }

    private GameObject GetRandomHouse()
    {
        if (houses.Length > 1)
        {
            int index = Random.Range(0, houses.Length);
            if (houses[index] != null)
            {
                // Return random house.
                return houses[index];
            }
            else
            {
                // Return default house.
                return houses[0];
            }
        }
        else
        {
            // Return default house.
            return houses[0];
        }
    }

    private float GetHouseWidth(GameObject house)
    {
        // Return house width (Z axis).
        return house.GetComponent<Collider>().bounds.size.z;
    }
}
