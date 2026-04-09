using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] alienPrefabs;
    public void Spawn()
    {
        int randomValue = Random.Range(0, alienPrefabs.Length);
        Vector3 V = alienPrefabs[randomValue].transform.position;
        V.z = Random.Range(226, 300);
        Instantiate(alienPrefabs[randomValue], V, alienPrefabs[randomValue].transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        float startDelay = 2;
        float spawnInterval = 3;
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
