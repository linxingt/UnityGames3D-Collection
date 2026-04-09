using System;
using System.Collections;
using UnityEngine;

public class sumoEnemy : MonoBehaviour
{
    public float intensity;
    public float maxSpeed;
    private Rigidbody rb;
    private GameObject Player;

    public bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    { 
      if(!isFrozen)
      {
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * intensity);
      }
    }

    public void Freeze()
    {
        if (!isFrozen) 
        {
            isFrozen = true;
            rb.linearVelocity = Vector3.zero;
            StartCoroutine(UnfreezeRoutine());
        }
    }

    IEnumerator UnfreezeRoutine()
    {
        yield return new WaitForSeconds(2);
        isFrozen = false;
    }
}
