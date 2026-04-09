using System.Collections;
using UnityEngine;

public class NeonCtrl : MonoBehaviour
{
    public GameObject cubeNeons;
    public Material matOff;
    public Material matOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            Clignote();
            timer = 0f;
        }
    }

    void SetMat(GameObject group, Material mat)
    {
        foreach (Transform child in group.transform)
        {
            GameObject obj = child.gameObject;
            obj.GetComponent<Renderer>().material = mat;
        }
    }

    public IEnumerator BlinkRoutine()
    {
        for (int i = 0; i < 3; i++)
        {
            SetMat(cubeNeons, matOn);  // Allumer
            yield return new WaitForSeconds(1f);
            SetMat(cubeNeons, matOff); // Éteindre
            yield return new WaitForSeconds(1f);
        }
    }

    public void Clignote()
    {
        StartCoroutine(BlinkRoutine());
        
    }
}
