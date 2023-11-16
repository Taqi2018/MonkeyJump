using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerSpawner : MonoBehaviour
{
    public Transform pillerPrefab;
    public float timeBetweenEachPiller;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PillerSpawnerMethod());
    }
    IEnumerator PillerSpawnerMethod()
    {
        Instantiate(pillerPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds( timeBetweenEachPiller);


        StartCoroutine(PillerSpawnerMethod());
    }
}
