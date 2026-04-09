using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetInteractionText()
    {
        return isOpen ? "Press R to Close" : "Press R to Open";
    }

    public void PerformAction(KeyCode c, GameObject Character)
    {
        if (c == KeyCode.R)
        {
            isOpen = !isOpen; // Bascule l'état (vrai devient faux, faux devient vrai)

            if (isOpen)
                transform.localEulerAngles = new Vector3(0, -90, 0); // Ouvre la porte
            else
                transform.localEulerAngles = new Vector3(0, 0, 0); // Ferme la porte
        }
    }
}
