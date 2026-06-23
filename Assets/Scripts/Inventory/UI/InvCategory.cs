using UnityEngine;
using UnityEngine.UI;

public class InvCategory : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject buttonContent;
    [SerializeField] private ItemTypeDataBase typeDatabase;

    private void Start()
    {
        foreach (ItemType type in typeDatabase.types)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContent.transform);
            button.GetComponent<Image>().sprite = type.icon;
            button.name = type.name;
            button.GetComponent<CategoryButton>().buttonType = type;
        }
    }

    public void UpdateCategorySort(ItemType _type)
    {
        inventoryUI.sortingType = _type;
        inventoryUI.updateUI();
    }

    public void ButtonAllPressed()
    {
        inventoryUI.sortingType = null;
        inventoryUI.updateUI();
    }

}
