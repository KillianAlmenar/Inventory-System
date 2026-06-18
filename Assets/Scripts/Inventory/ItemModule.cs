using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemModule : ScriptableObject
{
    public Item.TYPE type = Item.TYPE.NONE;

    [SerializeField] public List<Type> incompatibleModules = new List<Type>();
    public virtual void OnUse(Item item) { }

    public bool IsIncompatibleWith(ItemModule other)
    {
        if (other == null) return false;
        return incompatibleModules != null && incompatibleModules.Contains(other.GetType());
    }
}
