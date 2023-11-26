using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomtreespawner : MonoBehaviour
{
    public GameObject treePrefab; 
    public int numberOfTrees = 10; 
    public float spawnRadius = 10f; 

    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        Terrain terrain = Terrain.activeTerrain;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnTerrain(terrain);

            
            GameObject treeInstance = Instantiate(treePrefab, randomPosition, Quaternion.identity);

           
            AvoidTreeOverlap(treeInstance);
        }
    }

    Vector3 GetRandomPositionOnTerrain(Terrain terrain)
    {
        float randomX = Random.Range(0f, terrain.terrainData.size.x);
        float randomZ = Random.Range(0f, terrain.terrainData.size.z);
        float y = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + terrain.transform.position.y;

        return new Vector3(randomX, y, randomZ);
    }

    void AvoidTreeOverlap(GameObject tree)
    {
        Collider treeCollider = tree.GetComponent<Collider>();

        
        Collider[] colliders = Physics.OverlapSphere(tree.transform.position, spawnRadius);

        foreach (var collider in colliders)
        {
            if (collider != treeCollider && collider.CompareTag("Tree"))
            {
                
                Vector3 newPosition = GetRandomPositionOnTerrain(Terrain.activeTerrain);
                tree.transform.position = newPosition;

                
                AvoidTreeOverlap(tree);
                return;
            }
        }
    }
}
