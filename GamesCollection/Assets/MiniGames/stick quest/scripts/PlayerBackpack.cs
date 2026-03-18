using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackpack : MonoBehaviour
{
    private List<string> items = new List<string> { "stick", "stick" };
    public Transform inventoryUI;
    public List<Sprite> sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        int i = 0;

        foreach (Transform child in inventoryUI)
        {
            Image img = child.GetComponent<Image>();

            if (i < items.Count)
            {
                img.sprite = sprites.Find(s => s.name == items[i]);
                img.enabled = true;
                i++;
            }
            else
            {
                img.sprite = null;
                img.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(string name)
    {
        items.Add(name);
        RefreshUI();
    }
    public void RemoveItem(string name)
    {
        items.Remove(name);
        RefreshUI();
    }

    public int GetItemCount(string name)
    {
        return items.FindAll(i => i == name).Count;
    }
}
