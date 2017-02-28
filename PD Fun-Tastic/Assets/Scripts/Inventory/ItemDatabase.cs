using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase
{
    private static ItemDatabase instance = null;

    public static ItemDatabase GetInstance()
    {
        if (instance == null)
        {
            instance = new ItemDatabase();
            instance.Initialise();
        }
        return instance;
    }

    public float size = 0;

    private Dictionary<string,Item> itemList;
    private List<Item> consumableList;
    private List<Item> weaponryList;

    void Initialise()
    {
        //initialise itemlist
        itemList = new Dictionary<string, Item>();
        consumableList = new List<Item>();
        weaponryList = new List<Item>();

        Debug.Log("trying to load item");

        //load all item.asset from folder into list
        Item[] tempList;
        tempList = Resources.LoadAll<Item>("Scriptable Objects/Items");
        size = tempList.Length;
        //Debug.Log(tempList.Length);
        //loop through and add into dictionary(itemList)
        for (int i = 0; i < tempList.Length; ++i)
        {
            // check if there is already an item with same name
            // maybe slow but start is load time
            Item checker;
            if (itemList.TryGetValue(tempList[i].itemName, out checker) == false)
            {
                itemList.Add(tempList[i].itemName, tempList[i]);
                //Debug.Log(tempList[i].itemType);

                if (tempList[i].itemType == ItemType.Consumable)
                {
                    consumableList.Add(tempList[i]);
                }

                else 
                {
                    weaponryList.Add(tempList[i]);
                }
                //Debug.Log(tempList[i].ability.aName);
            }
            // retard checkers
            else 
            {
                Debug.Log("Item With Same Name!! DONT RETARD PLS");
                Debug.Log(tempList[i].atk);
            }
            //More retard checkers
            if (tempList[i].itemName == "")
            {
                Debug.Log("ITEM NO NAME LA RETARD");
            }
           
        }
    }


    public Item GetItem(string name)
    {
        Item temp;
        if (itemList.TryGetValue(name, out temp) == true)
        {
            return temp;
        }

        return null;
    }

    public List<Item> GetConsumableList()
    {
        return consumableList;
    }

    public List<Item> GetWeaponryList()
    {
        return weaponryList;
    }
}