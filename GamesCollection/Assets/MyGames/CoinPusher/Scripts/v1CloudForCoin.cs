using System.Collections;
using UnityEngine;

public class v1CloudForCoin : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnDelay; // 10 pièces par seconde

    private BoxCollider boxCollider;

    public Transform coinsContainer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(SpawnLoop());
    }
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Vector3 P = GetRandomPointInside(); // Position aléatoire
            Instantiate(coinPrefab, P, Quaternion.Euler(90f, 0f, 0f), coinsContainer);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void Update()
    {

    }

    public Vector3 GetRandomPointInside()
    {
        Vector3 size = boxCollider.size;
        Vector3 center = boxCollider.center;

        Vector3 localRandom = new Vector3(
                Random.Range(-size.x / 2f, size.x / 2f),
                Random.Range(-size.y / 2f, size.y / 2f),
                Random.Range(-size.z / 2f, size.z / 2f)
        );

        // Transform to world coordinates considering scale and rotation
        return boxCollider.transform.TransformPoint(center + localRandom);
    }

    
}
