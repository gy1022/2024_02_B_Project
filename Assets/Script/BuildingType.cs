using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    CraftingTalbe,
    Furnace,
    Kitchen,
    Storage
}

[System.Serializable]

public class CtaftingPecipe
{
    public string itemName;
    public ItemType resultItem;
    public int resultAmount = 1;

    public float hungerRestoreAmount;
    public float repairAmount;

    public ItemType[] requiredItems;
    public int[] requiredAmounts;
}
