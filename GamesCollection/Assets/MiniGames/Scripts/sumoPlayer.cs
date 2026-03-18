using System;
using System.Collections;
using UnityEngine;

public class sumoPlayer : MonoBehaviour
{
    public float intensity;
    public float maxSpeed;
    public bool hasPowerUp;
    public GameObject indicatorGroup;
    private Rigidbody rb;
    private Coroutine powerupCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        hasPowerUp = false;
        indicatorGroup.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        Debug.Log(velocity.magnitude);

        if (velocity.magnitude > maxSpeed)
            rb.linearVelocity = velocity.normalized * maxSpeed;

        float dT = Time.deltaTime;
        float vInput = Input.GetAxis("Vertical");

        GameObject cam = GameObject.Find("Main Camera");
        GameObject center = GameObject.Find("Focal Point");

        Vector3 V = center.transform.position - cam.transform.position;
        V.y = 0; // horizontal vector
        V.Normalize();

        rb.AddForce(V * intensity * vInput);


        float hInput = Input.GetAxis("Horizontal");
        Vector3 V2 = Quaternion.Euler(0, 90, 0) * V;
        rb.AddForce(V2 * intensity * hInput);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            indicatorGroup.SetActive(true);

            if (powerupCoroutine != null) StopCoroutine(powerupCoroutine);
            powerupCoroutine = StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * intensity * 1.3f);

            sumoEnemy enemy = collision.gameObject.GetComponent<sumoEnemy>();
            if (enemy != null)
            {
                enemy.Freeze();
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);

        hasPowerUp = false;
        indicatorGroup.SetActive(false);
    }
}
