using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTigger : MonoBehaviour
{
    public Material Mat_in;
    public GameObject objectChange;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = objectChange.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        objectRenderer.material = Mat_in;
    }
    }
