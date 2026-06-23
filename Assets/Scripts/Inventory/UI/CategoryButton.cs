using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButton : MonoBehaviour
{
    public ItemType buttonType;
    public void ButtonPressed()
    {
        GetComponentInParent<InvCategory>().UpdateCategorySort(buttonType);
    }
}
