using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSpawnController : MonoBehaviour
{
    public bool randomlySpawnUnits;

    // Use this for initialization
    void Start()
    {

    }

    // Returns a vector of locations that units may spawn from
    List<Vector3> GetRandomSpawnLocations(float innerRadius, float outerRadius, int numberOfSpawnLocations)
    {
        // Make sure units won't be spawned outside the right area
        if (GameObject.FindGameObjectWithTag("Landscape").transform.localScale.x < outerRadius ||
            GameObject.FindGameObjectWithTag("Landscape").transform.localScale.z < outerRadius ||
            outerRadius < innerRadius)
        {
            Debug.Log("Cannot spawn units from locations outside of the Landscape object, or have innerRadius larger than outerRadius");
            return null;
        }
        List<Vector3> randomSpawnLocations = new List<Vector3>();
        for (int i = 0; i < numberOfSpawnLocations; i++)
        {
            Vector3 randomSpawnLocation = new Vector3(Random.Range(innerRadius, outerRadius), 0, Random.Range(innerRadius, outerRadius));
            // Move spawn locations to one metre above the ground
            RaycastHit hitInfo;
            //if (Physics.Raycast(randomSpawnLocation, transform.up, out hitInfo)
            //numberOfSpawnLocations.Add();
        }
        return randomSpawnLocations;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
