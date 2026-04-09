using UnityEngine;

public class WallCrosshair : MonoBehaviour
{
    public Transform crosshair; 
    public GameObject coinPrefab;  
    public float coinForwardForce = 5f; // Force pour "pousser" la pièce au lancement
    public float smoothSpeed = 20f; // Vitesse de déplacement du viseur

    private Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = crosshair.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacement fluide (Lerp) pour que ce soit agréable à l'oeil
        crosshair.position = Vector3.Lerp(crosshair.position, targetPosition, Time.deltaTime * smoothSpeed);
        //crosshair.position = targetPosition;
    }

    void OnMouseOver()
    {
        // Créer le rayon qui part de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            float fixedHeight = transform.position.y;
            targetPosition = new Vector3(hit.point.x, fixedHeight, hit.point.z-0.1f);
        }
    }
    void OnMouseDown()
    {
        if (coinPrefab != null)
        {
            // Instancier la pièce à la position du viseur
            GameObject newCoin = Instantiate(coinPrefab, crosshair.position, Quaternion.identity);

            // Ajouter une vitesse initiale pour qu'elle soit "propulsée" vers l'avant
            Rigidbody rb = newCoin.GetComponentInChildren<Rigidbody>();
            if (rb != null)
            {
                // On pousse la pièce
                rb.AddForce(Vector3.down * coinForwardForce, ForceMode.Impulse);
            }
        }
    }
}
