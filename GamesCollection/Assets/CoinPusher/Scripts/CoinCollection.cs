using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public List<TextMeshProUGUI> countTexts;
    public TextMeshProUGUI totalMoneyText;
    public GameObject grpNeonsB;
    public GameObject grpNeonsJ;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private Dictionary<string, float> coinValues = new Dictionary<string, float>()
    {
        {"chip1", 1f}, {"chip2", 2f}, {"chip5", 5f}, {"chip10", 10f},
        {"coinEuro", 1f}, {"coinSilver", 0.5f}, {"coinLincoln", 0.01f}
    };
    private float totalMoney = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (string key in coinValues.Keys)
        {
            inventory.Add(key, 0);
        }
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision avec : " + other.transform.parent.name);
        // On vérifie si ce nom existe dans nos types gérés
        if (other.transform.parent.name.Contains("chip1"))
        {
            inventory["chip1"]++;
            totalMoney += coinValues["chip1"];
        }
        else if (other.transform.parent.name.Contains("chip2"))
        {
            inventory["chip2"]++;
            totalMoney += coinValues["chip2"];
        }
        else if (other.transform.parent.name.Contains("chip5"))
        {
            inventory["chip5"]++;
            totalMoney += coinValues["chip5"];
        }
        else if (other.transform.parent.name.Contains("chip10"))
        {
            inventory["chip10"]++;
            totalMoney += coinValues["chip10"];
        }
        else if (other.transform.parent.name.Contains("coinEuro"))
        {
            inventory["coinEuro"]++;
            totalMoney += coinValues["coinEuro"];
        }
        else if (other.transform.parent.name.Contains("coinSilver"))
        {
            inventory["coinSilver"]++;
            totalMoney += coinValues["coinSilver"];
        }
        else if (other.transform.parent.name.Contains("coinLincoln"))
        {
            inventory["coinLincoln"]++;
            totalMoney += coinValues["coinLincoln"];
        }
        grpNeonsB.GetComponent<NeonCtrl>().Clignote();
        grpNeonsJ.GetComponent<NeonCtrl>().Clignote();
        Destroy(other.gameObject);
        UpdateUI();
    }

    void UpdateUI()
    {
        // Mise à jour des compteurs individuels
        // l'ordre dans la liste 'countTexts' correspond à l'ordre dans 'coinValues'
        int i = 0;
        foreach (var item in inventory)
        {
            if (i < countTexts.Count)
            {
                countTexts[i].text = item.Value.ToString();
                i++;
            }
        }

        // Mise à jour de l'argent total
        if (totalMoneyText != null)
        {
            totalMoneyText.text = totalMoney.ToString() + "€";
        }
    }
}
