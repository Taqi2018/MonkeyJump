using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerMovement : MonoBehaviour
{
    public float pillerMovementSpeed;
    float  lifeTime;
    public float dieTime;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
    }


    // Update is called once per frame
    void Update()
    {
       
        lifeTime += Time.deltaTime;
        transform.position += Vector3.down*Time.deltaTime*pillerMovementSpeed;
        Debug.Log($"{transform.name} :  {lifeTime}");
        if (lifeTime >= dieTime)
        {

            lifeTime = 0;
            this.gameObject.SetActive(false);
         
        }

    }
}
