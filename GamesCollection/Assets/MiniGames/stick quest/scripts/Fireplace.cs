using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    public MeshRenderer interiorRenderer; 
    public PlayerBackpack playerBackpack;   
    private bool isLit = false;
    
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
        if (isLit) return "Fire is burning";
        return "Press R to light fire (Needs 5 sticks)";
    }

    public void PerformAction(KeyCode c, GameObject Character)
    {
        if (c == KeyCode.R)
        {
            if (isLit) LightFire();

            // 1. Vérifier si le joueur a 5 bâtons
            if (playerBackpack.GetItemCount("stick") >= 5)
            {
                // 2. Retirer les bâtons du sac
                for (int i = 0; i < 5; i++)
                {
                    playerBackpack.RemoveItem("stick");
                }

                // 3. Allumer le feu
                LightFire();
            }
        }
    }
    void LightFire()
    {
        isLit = true;
        interiorRenderer.material.color = interiorRenderer.material.color == Color.red ? Color.yellow : Color.red;
    }

}
