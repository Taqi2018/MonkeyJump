using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
     public float obstacleMovementSpeed;
     float lifeTime;
     public float dieTime;
     public float dmgValue = 20f;

     // Start is called before the first frame update
     void Start()
     {
          lifeTime = 0;
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Player"))
          {
               // Player has hit an obstacle
               GameManager.Instance.DealDamage(dmgValue);

               // Deactivate the collectable object
               gameObject.SetActive(false);
          }
     }


     // Update is called once per frame
     void Update()
     {

          lifeTime += Time.deltaTime;
          transform.position += Vector3.down * Time.deltaTime * Random.Range(obstacleMovementSpeed - 3, obstacleMovementSpeed + 3);
          Debug.Log($"{transform.name} :  {lifeTime}");
          if (lifeTime >= dieTime)
          {

               lifeTime = 0;
               this.gameObject.SetActive(false);

          }

     }
}
