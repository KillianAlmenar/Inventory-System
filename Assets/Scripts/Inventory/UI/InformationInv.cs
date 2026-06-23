using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InformationInv : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private TextMeshProUGUI weight;
    [SerializeField] private Image icon;

    public void SetInformations(Item _selectedItem)
    {
        itemName.text = _selectedItem.name;
        description.text = _selectedItem.description;
        icon.sprite = _selectedItem.icon;
        rarity.text = _selectedItem.rarity.displayName;
        weight.text = _selectedItem.weight.ToString() + " lbs";

    }

}