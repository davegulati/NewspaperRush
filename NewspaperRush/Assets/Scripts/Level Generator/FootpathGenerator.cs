using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootpathGenerator : MonoBehaviour
{

    private Transform player;
    private float generationDistance = 100.0f;

    public GameObject[] footpaths;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= generationDistance)
        {
            GenerateFootpath();
        }
    }

    public void GenerateFootpath()
    {
        // Generate random footpath tile.
        GameObject randomFootpath = GetRandomFootpath();
        GameObject generatedFootpath = Instantiate(randomFootpath, gameObject.transform.position, Quaternion.identity);

        // Move the generator along the Z axis.
        float generatedFootpathWidth = GetFootpathWidth(generatedFootpath);
        Vector3 currentPosition = transform.position;
        currentPosition.z = currentPosition.z + generatedFootpathWidth;
        transform.position = currentPosition;
    }

    private GameObject GetRandomFootpath()
    {
        if (footpaths.Length > 1)
        {
            int index = Random.Range(0, footpaths.Length);
            if (footpaths[index] != null)
            {
                // Return random footpath.
                return footpaths[index];
            }
            else
            {
                // Return default footpath.
                return footpaths[0];
            }
        }
        else
        {
            // Return default footpath.
            return footpaths[0];
        }
    }

    private float GetFootpathWidth(GameObject footpath)
    {
        // Return footpath width (Z axis).
        return footpath.GetComponent<Collider>().bounds.size.z;
    }
}
