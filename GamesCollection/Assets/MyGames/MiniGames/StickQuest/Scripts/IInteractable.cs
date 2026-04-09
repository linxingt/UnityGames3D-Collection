using UnityEngine;

public interface IInteractable
{
    string GetInteractionText();
    void PerformAction(KeyCode c, GameObject Character);
}
