using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerSpawner : MonoBehaviour
{
    public Transform pillerPrefab;
    public List <Transform>  pillerPrefabCollection;
    public float timeBetweenEachPiller;
    public int totalPillerCollection;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(PillerSpawnerMethod());
        for(int i = 0; i < totalPillerCollection; i++)
        {
            Transform piller= Instantiate(pillerPrefab, transform.position, Quaternion.identity);
            piller.gameObject.SetActive(false);
            pillerPrefabCollection.Add(piller);
        }
    }
    IEnumerator PillerSpawnerMethod()
    {
        foreach (Transform i in pillerPrefabCollection)
        {
            if (i.gameObject.activeInHierarchy==false)
            {
                i.gameObject.SetActive(true);
                i.transform.position = this.transform.position;
                break;
            }
        }
        yield return new WaitForSeconds( timeBetweenEachPiller);


        StartCoroutine(PillerSpawnerMethod());
    }
}
