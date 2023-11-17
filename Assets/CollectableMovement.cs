using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
     public float collectableMovementSpeed;
     float lifeTime;
     public float dieTime;
     public int scoreValue = 100;

     // Start is called before the first frame update
     void Start()
     {
          lifeTime = 0;
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Player"))
          {
               // Player has collected the collectable
               GameManager.Instance.AddScore(scoreValue);

               // Deactivate the collectable object
               gameObject.SetActive(false);
          }
     }


     // Update is called once per frame
     void Update()
     {

          lifeTime += Time.deltaTime;
          transform.position += Vector3.down * Time.deltaTime * Random.Range(collectableMovementSpeed-3 ,collectableMovementSpeed+3);
          Debug.Log($"{transform.name} :  {lifeTime}");
          if (lifeTime >= dieTime)
          {

               lifeTime = 0;
               this.gameObject.SetActive(false);

          }

     }
}
