using UnityEditor;
using UnityEngine;

public class sumoManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform cylinderTransform;

    bool positionValide = false;
    Vector3 pointPropose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float radius = cylinderTransform.localScale.x / 2f;
        pointPropose = enemyPrefab.transform.position;
        
        while(!positionValide){
            float randomX = Random.Range(cylinderTransform.position.x-radius, cylinderTransform.position.x + radius);
            float randomZ = Random.Range(cylinderTransform.position.z-radius, cylinderTransform.position.z + radius);


            float distance = Vector3.Distance(new Vector3(randomX, 0, randomZ), new Vector3(cylinderTransform.position.x, 0, cylinderTransform.position.z));

                if (distance <= radius)
                {
                    positionValide = true;
                    pointPropose.x = randomX;
                    pointPropose.z = randomZ;
                }
        }

        Instantiate(enemyPrefab, pointPropose, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
