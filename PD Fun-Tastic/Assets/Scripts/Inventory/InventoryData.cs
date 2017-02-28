using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryData
{
    private static InventoryData instance = null;

    private List<Item> equipmentSlots;

    private List<Item> inventoryStorage;
    public Item draggedItem;

    public static InventoryData GetInstance()
    {
        if (instance == null)
        {
            instance = new InventoryData();
            instance.Initialise();
        }
        return instance;
    }

    void Initialise()
    {
      

       draggedItem = null;

        const int initialStorageSize = 36;
        equipmentSlots = new List<Item>();
        inventoryStorage = new List<Item>();
        //Set initial empty items to null
        for (int i = 0; i < initialStorageSize; ++i)
        {
            inventoryStorage.Add(null);
        }

        for (int i = 0; i < 5; ++i)
        {
            equipmentSlots.Add(null);
        }
        //init starting items

        AddItemToInventory("Legs");

    }

    public void ChangeSlotItem(int index, Item item)
    {
        inventoryStorage[index] = item;
    }
    public Item GetSlotItem(int index)
    {
        return inventoryStorage[index];
    }

    public bool AddItemToInventory(Item item)
    {
        for (int i = 0; i < inventoryStorage.Count; ++i)
        {
            if (inventoryStorage[i] == null)
            {
                inventoryStorage[i] = item;
                return true;
            }
        }
        return false;
    }

    public Item GetEquipment(ItemType type)
    {
        return equipmentSlots[(int)type];
    }

    public void ChangeEquipment(ItemType type, Item item)
    {
        equipmentSlots[(int)type] = item;
    }

    public bool AddItemToInventory(string itemName)
    {
        return AddItemToInventory(ItemDatabase.GetInstance().GetItem(itemName));
    }

    public void CloseInventory()
    {
        if (draggedItem != null)
        {
            AddItemToInventory(draggedItem);

            draggedItem = null;
        }
    }
    

}
