using UnityEngine;

public class AlienAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float dodgeDistance = 4f;

    private Vector3 targetPosition;
    private bool isDodging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, moveSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pizza détectée au loin ! Esquive.");
        StartDodge();
    }

    void StartDodge()
    {
        isDodging = true;

        // Décider aléatoirement : -1 (gauche) ou 1 (droite)
        float direction = Random.value > 0.5f ? 1f : -1f;

        targetPosition = transform.parent.position + new Vector3(0, 0, direction * dodgeDistance);
    }
}
