using UnityEngine;

public class Stick : MonoBehaviour, IInteractable
{
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
        return "Press R to collect";
    }

    public void PerformAction(KeyCode c, GameObject Character)
    {
        if (c == KeyCode.R)
        {
            PlayerBackpack backpack = Character.GetComponent<PlayerBackpack>();

            if (backpack != null)
            {
                backpack.AddItem("stick");
                Destroy(gameObject);
            }
        }
    }
}
