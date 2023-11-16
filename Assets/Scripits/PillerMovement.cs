using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerMovement : MonoBehaviour
{
    public float pillerMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime*pillerMovementSpeed;
    }
}
