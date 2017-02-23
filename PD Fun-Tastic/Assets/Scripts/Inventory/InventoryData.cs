using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryData {

    public List<Item> inventoryItemList = new List<Item>();

    private static InventoryData instance = null;

    public static InventoryData GetInstance()
    {
        if (instance == null)
        {
            instance = new InventoryData();
        }
        return instance;
    }

    public List<Item> GetItemList()
    {
        return inventoryItemList;
    }

}
