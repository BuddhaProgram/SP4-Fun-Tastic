using UnityEngine;
using System;
using System.Collections;

public class LoadAllSavedItemsToInventory{
    static int[] i_allItemID = new int[Int16.MaxValue];
    static ItemDatabase _itemListInstance = ItemDatabase.GetInstance();
    static InventoryData _InventoryListInstance = InventoryData.GetInstance();


    public static void GetInventoryItemsFromKey(string keyName)
    {
        int i_arrayLength = 0;
        if (PlayerPrefs.HasKey(keyName))
        {
            i_arrayLength = checked(PlayerPrefsX.GetIntArray(keyName).Length);

            for (int i = 0; i < i_arrayLength; ++i)
            {
                i_allItemID[i] = PlayerPrefsX.GetIntArray(keyName)[i];

                if (_itemListInstance.items[i].GetItemID() == i_allItemID[i])
                {
                    _InventoryListInstance.inventoryItemList.Add(_itemListInstance.items[i]);
                }
            }
        }

        else
        {
            return;
        }

    }
}
