using UnityEngine;

public class Pusher : MonoBehaviour
{
    private float omega;
    private float posInitial;
    private Rigidbody rb;

    [Header("Paramètres de mouvement")]
    public float moveDistance =1.0f;
    public float period = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posInitial = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float omega = (2f * Mathf.PI) / period;

        // z(t) = z0 + K * sin(w * t)
        float newZ = posInitial + moveDistance * Mathf.Sin(omega * Time.time);

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZ);

        rb.MovePosition(newPosition);
    }
}
