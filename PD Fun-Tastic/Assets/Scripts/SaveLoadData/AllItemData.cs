using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AllItemData : MonoBehaviour {
    ItemDatabase _itemListInstance = ItemDatabase.GetInstance();
    public GameObject _loadItemsToInventory;

    public string s_fileName;
    public string s_keyName;
	// Use this for initialization
	void Start () {
        LoadAllItemsFile();
        LoadAllSavedItemsToInventory.GetInventoryItemsFromKey(s_keyName);
        _loadItemsToInventory.GetComponent<LoadAllConsumables>().LoadAllConsumableItems();
        _loadItemsToInventory.GetComponent<DisplayAllConsumables>().LoadToShopList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadAllItemsFile()
    {
        try
        {
            StreamReader theReader = new StreamReader(s_fileName, Encoding.Default);
            using (theReader)
            {
                string s_line = "";
                string itemName = null;
                int itemID = 0;
                string itemDescription = null;
                string itemAbility = null;
                int attackValue = 0;
                int vitalityValue = 0;
                int agilityValue = 0;
                int itemStack = 0;
                Item.ItemType itemType = 0;

                do
                {
                    s_line = theReader.ReadLine();

                    if (s_line != null)
                    {
                        if (s_line.Contains("itemName = ") == true)
                        {
                            itemName = s_line.Substring(s_line.IndexOf("=") + 2);
                        }

                        else if (s_line.Contains("itemID") == true)
                        {
                            itemID = int.Parse(s_line.Substring(s_line.IndexOf("=") + 2));
                        }

                        else if (s_line.Contains("itemDescription = ") == true)
                        {
                            itemDescription = s_line.Substring(s_line.IndexOf("=") + 2);
                        }

                        else if (s_line.Contains("itemAbility = ") == true)
                        {
                            itemAbility = s_line.Substring(s_line.IndexOf("=") + 2); 
                        }

                        else if (s_line.Contains("attackValue") == true)
                        {
                            attackValue = int.Parse(s_line.Substring(s_line.IndexOf("=") + 2));
                        }

                        else if (s_line.Contains("vitalityValue") == true)
                        {
                            vitalityValue = int.Parse(s_line.Substring(s_line.IndexOf("=") + 2));
                        }

                        else if (s_line.Contains("agilityValue") == true)
                        {
                            agilityValue = int.Parse(s_line.Substring(s_line.IndexOf("=") + 2));
                        }

                        else if (s_line.Contains("itemStack = ") == true)
                        {
                            itemStack = int.Parse(s_line.Substring(s_line.IndexOf("=") + 2));
                        }

                        else if (s_line.Contains("itemType") == true)
                        {
                            string s_type = "";
                            s_type = s_line.Substring(s_line.IndexOf("=") + 1); 
                            itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), s_type);
                        }

                        else if (s_line.Contains("end") == true)
                        {
                            Item item = new Item(itemName, itemID, attackValue, vitalityValue, agilityValue, itemStack, itemType, itemAbility, itemDescription);
                            _itemListInstance.items.Add(item);
                        }
                    }
                }
                while (s_line != null);
                theReader.Close();
            }
        }

        catch (DirectoryNotFoundException)
        {

        }
    }
}
