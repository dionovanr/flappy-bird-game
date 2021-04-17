using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipa;
    public float SpawnTime;
    public float yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipaCoroutine());

    }

    IEnumerator SpawnPipaCoroutine()
    {
        yield return new WaitForSeconds(SpawnTime);
        Instantiate(Pipa, transform.position + Vector3.up * Random.Range(yMin,yMax) , Quaternion.identity);
        StartCoroutine(SpawnPipaCoroutine());
    }
   
}
