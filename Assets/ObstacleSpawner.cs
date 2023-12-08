using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
     public GameObject obstacleObjectPrefab;
     public int poolSize = 10;
     public float spawnRate = 2f;
     public float spawnHeight = 7f;

     private List<GameObject> pooledObstacles;
     private float timeSinceLastSpawn = 0f;

     void Start()
     {
          pooledObstacles = new List<GameObject>();
          for (int i = 0; i < poolSize; i++)
          {
               GameObject collectableObject = Instantiate(obstacleObjectPrefab, Vector2.zero, Quaternion.identity);
               collectableObject.SetActive(false);
               pooledObstacles.Add(collectableObject);
          }
     }

     void Update()
     {
          timeSinceLastSpawn += Time.deltaTime;
          if (timeSinceLastSpawn > spawnRate)
          {
               timeSinceLastSpawn = 0f;
               SpawnObstacle();
          }
     }

     void SpawnObstacle()
     {
          for (int i = 0; i < pooledObstacles.Count; i++)
          {
               if (!pooledObstacles[i].activeInHierarchy)
               {
                    float randomX = Random.Range(-2f, 2f);
                    pooledObstacles[i].transform.position = new Vector2(randomX, spawnHeight);
                    pooledObstacles[i].SetActive(true);
                    break;
               }
          }
     }
}
