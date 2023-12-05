using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public Transform player;
     public float xDistance;
     public float speed;

     Vector3 dirToJump;
     private float previousTime;
     public float timeDelayForJump;



     // Start is called before the first frame update
     void Start()
     {

          dirToJump = Vector3.right;
          previousTime = 0;
     }

     // Update is called once per frame
     void Update()
     {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               float spacePressedTime = Time.time;
               float timeDelayBetweenJump = spacePressedTime - previousTime;

               if (timeDelayBetweenJump > timeDelayForJump)
               {
                    Vector3 targetPosition = player.position + dirToJump * xDistance;
                    StartCoroutine(MovePlayerToPosition(targetPosition, speed));
                    dirToJump = -dirToJump;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                    previousTime = spacePressedTime;

               }



          }
     }

     IEnumerator MovePlayerToPosition(Vector3 targetPosition, float moveSpeed)
     {
          float elapsedTime = 0f;
          Vector3 startingPos = player.position;

          while (elapsedTime < 1f)
          {

               player.position = Vector3.Lerp(startingPos, targetPosition, elapsedTime);
               Debug.Log(player.position);
               elapsedTime += Time.deltaTime * moveSpeed;
               yield return null;


          }

          //   player.position = targetPosition;
     }
}
