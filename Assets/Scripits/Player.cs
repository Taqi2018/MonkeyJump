using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;
    public float xDistance;
    public float speed;
    Vector3 dirToJump;

    // Start is called before the first frame update
    void Start()
    {
        dirToJump = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 targetPosition = player.position + dirToJump*xDistance;
            StartCoroutine(MovePlayerToPosition(targetPosition, speed));

            dirToJump = -dirToJump;
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
