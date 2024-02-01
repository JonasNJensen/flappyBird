using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDistance = 20f;  // Distance in front of the player
    public float maxHeight = 3f;  // Maximum height relative to the camera's height
    public float minHeight = 2f;  // Maximum height relative to the camera's height
    public float despawnDistance = 20f;  // Distance to the left of the player to despawn objects
    public float spawnInterval = 2f;  // Time interval between spawns

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Transform gameMapTransform;  // Reference to the "Game Map" GameObject's Transform

    void Start()
    {
        // Find the "Game Map" GameObject in the scene by name
        gameMapTransform = GameObject.Find("Game Map").transform;

        if (gameMapTransform == null)
        {
            Debug.LogError("Game Map not found in the scene. Make sure it exists and has the correct name.");
        }

        // Start spawning objects with the specified interval
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void Update()
    {
        DespawnObjects();
    }

    void SpawnObject()
    {
        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Calculate the spawn position in front of the player
        Vector3 spawnPosition = playerPosition + transform.right * spawnDistance;

        // Get the camera's height
        float cameraHeight = Camera.main.transform.position.y;

        // Calculate a random height within the camera's view but above the ground
        float randomHeight = Random.Range(cameraHeight - minHeight, cameraHeight + maxHeight);

        // Set the spawn position's y coordinate to the random height
        spawnPosition.y = randomHeight;

        // Spawn the prefab at the calculated position
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Set the "Game Map" as the parent of the spawned prefab
        if (gameMapTransform != null)
        {
            spawnedPrefab.transform.SetParent(gameMapTransform);
        }

        // Add the spawned prefab to the list
        spawnedObjects.Add(spawnedPrefab);
    }

    void DespawnObjects()
    {
        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Iterate through the spawned objects
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            // Check if the object has moved to the left of the player beyond the despawn distance
            if (spawnedObjects[i].transform.position.x < playerPosition.x - despawnDistance)
            {
                // Destroy the object and remove it from the list
                Destroy(spawnedObjects[i]);
                spawnedObjects.RemoveAt(i);
                i--;  // Decrement i to account for the removed object
            }
        }
    }
}
