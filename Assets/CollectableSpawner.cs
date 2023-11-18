using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
     public GameObject collectableObjectPrefab;
     public int poolSize = 10;
     public float spawnRate = 2f;
     public float spawnHeight = 7f;

     private List<GameObject> pooledCollectableObjects;
     private float timeSinceLastSpawn = 0f;

     void Start()
     {
          pooledCollectableObjects = new List<GameObject>();
          for (int i = 0; i < poolSize; i++)
          {
               GameObject collectableObject = Instantiate(collectableObjectPrefab, Vector2.zero, Quaternion.identity);
               collectableObject.SetActive(false);
               pooledCollectableObjects.Add(collectableObject);
          }
     }

     void Update()
     {
          timeSinceLastSpawn += Time.deltaTime;
          if (timeSinceLastSpawn > spawnRate)
          {
               timeSinceLastSpawn = 0f;
               SpawnCollectableObject();
          }
     }

     void SpawnCollectableObject()
     {
          for (int i = 0; i < pooledCollectableObjects.Count; i++)
          {
               if (!pooledCollectableObjects[i].activeInHierarchy)
               {
                    float randomX = Random.Range(-2f, 2f); 
                    pooledCollectableObjects[i].transform.position = new Vector2(randomX, spawnHeight);
                    pooledCollectableObjects[i].SetActive(true);
                    break;
               }
          }
     }
}
