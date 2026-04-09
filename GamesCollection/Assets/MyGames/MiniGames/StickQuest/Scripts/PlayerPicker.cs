using UnityEngine;
using TMPro;

public class PlayerPicker : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 30f;
    public LayerMask interactableLayer;

    public TextMeshProUGUI interactionText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer)) { 
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

        if (interactable != null)
            interactionText.text = interactable.GetInteractionText();

            if (Input.GetKeyDown(KeyCode.R))
                interactable.PerformAction(KeyCode.R, gameObject);
        }
        else
            interactionText.text = "+";
    }
}
