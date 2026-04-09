using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 25f;                // Speed of the character
    public float rotationSpeed = 200f;      // Speed of rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // Rotate character
        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);

        // Moves the character forward
        characterController.SimpleMove(transform.forward * vInput * speed);
    }
}
