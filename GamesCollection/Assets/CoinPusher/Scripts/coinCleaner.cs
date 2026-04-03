using UnityEngine;

public class coinCleaner : MonoBehaviour
{
    public float limitY = -0.99f; // en dessous de laquelle la pièce est détruite
    public float maxDist = 0.2f; // distance du rayon sous la pièce
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * maxDist, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDist))
        {
            string N = hit.collider.gameObject.name;

            if (N.Contains("Side") || N.Contains("combine") || N.Contains("coins") || N.Contains("stack") || N.Contains("pile") || N.Contains("euros"))
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        if (transform.position.y < limitY)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject); 
            } // Détruit la pièce
        }
    }
}
