using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlayer : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float hInput;
    public GameObject pizzaSlice;
    public float maxSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaSlice, transform.position + transform.right * -10.5f, pizzaSlice.transform.rotation);
        }
    }

    protected void FixedUpdate()
    {
        m_Rigidbody.linearVelocity = transform.forward * hInput * maxSpeed;

        
    }
}
