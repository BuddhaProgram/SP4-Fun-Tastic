using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryData {

    
   //private int rows = 9;
    //private int col = 4;
    [SerializeField]
    private List<Item> inventoryItemList;
    private static InventoryData instance;
    static int numStarted = 0;

    public static InventoryData GetInstance()
    {
        if (instance == null)
        {
            instance = new InventoryData();
            instance.Start();
            Debug.Log("Num Started: " + numStarted++);
        }
        return instance;
    }

    public List<Item> GetItemList()
    {
        return inventoryItemList;
    }

    void Start()
    {
        int rows = 9;
        int col = 4;
        inventoryItemList = new List<Item>();
        //Debug.Log("Row: " + rows);
        //Debug.Log("Column: " + col);
        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < col; k++)
            {
                //Debug.Log("i: " + i);
                //Debug.Log("k: " + k);
                //Item item = new Item();
                inventoryItemList.Add(new Item());
            }
        }
        //Debug.Log("Num Stuff: " + inventoryItemList.Count);
        
    }

    public void AddItem(string itemName)
    {
        //foreach (Item item in inventoryItemList)
        //{
        //    if (item.itemType == Item.ItemType.None)
        //    {
        //       item = ItemDatabase.GetInstance().GetItem(itemName);
        //    }
        //}

        for (int i = 0; i < 9*4; ++i)
        {
            if (inventoryItemList[i].itemType == Item.ItemType.None)
            {
                inventoryItemList[i] = ItemDatabase.GetInstance().GetItem(itemName);
                return;
            }
        }

    }
}
