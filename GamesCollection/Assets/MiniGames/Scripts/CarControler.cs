using UnityEngine;

public class CarControler : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float rotSpeed = 360.0f;
    public float maxSpeed = 30.0f;
    void Start() {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        Debug.Log(hInput);
        transform.Rotate(0, hInput * dt * rotSpeed, 0);
        //transform.Rotate(Vector3.up, rotSpeed * dT * hInput
        //Vector3.up : C'est un raccourci qui veut dire exactement (0, 1, 0)
        //tourne autour de l'axe qui pointe vers le haut (Y)

    }
    protected void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Rigidbody.velocity = transform.forward * maxSpeed;
        }

    }
}