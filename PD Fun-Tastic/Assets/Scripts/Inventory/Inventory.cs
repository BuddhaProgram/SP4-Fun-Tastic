using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public List<GameObject> Slots = new List<GameObject>();

    public List<Item> items = InventoryData.GetInstance().GetItemList();
    public InventoryData _allItemsInInventory;

    public GameObject slots;
    ItemDatabase database;
    public GameObject tooltip;

    public GameObject player;
    public GameObject characterGear;
    public GameObject goldPanel;
    //public GameObject hotbarPrimary;
    //public GameObject hotbarSecondary;

    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public Item draggedItem;
    public int indexOfDraggedItem;

    public int gold;

    void Update()
    {
        if (draggingItem)
        {
            Vector3 pos = (Input.mousePosition - GameObject.FindGameObjectWithTag("Inventory BG").GetComponent<RectTransform>().localPosition);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(Input.mousePosition.x - 470, Input.mousePosition.y - 300, pos.z); //new Vector3(pos.x - 400, pos.y - 450, pos.z);
        }

        showCharacterStats();
        DisplayGoldText();
    }

    public void showCharacterStats()
    {
        characterGear.transform.GetChild(4).GetComponent<Text>().text = "Attack: " + player.GetComponent<Status>().GetAtk().ToString();
        characterGear.transform.GetChild(5).GetComponent<Text>().text = "Vitality: " + player.GetComponent<Status>().GetVit().ToString();
        characterGear.transform.GetChild(6).GetComponent<Text>().text = "Agility: " + player.GetComponent<Status>().GetAgi().ToString();
    }   

    public void showTooltip(Vector3 toolPosition, Item item)
    {
        tooltip.SetActive(true);
        tooltip.GetComponent<RectTransform>().localPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);//new Vector3(toolPosition.x + 5, toolPosition.y - 300, toolPosition.z);

        tooltip.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        tooltip.transform.GetChild(1).GetComponent<Text>().text = item.itemAbility;
        tooltip.transform.GetChild(2).GetComponent<Text>().text = item.itemDesc;
    }

    public void showDraggedItem(Item item, int slotNumber)
    {
        indexOfDraggedItem = slotNumber;
        draggedItemGameObject.SetActive(true);
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
        draggingItem = true;
        draggedItem = item;
        closeTooltip();
    }

    public void closeDraggedItem()
    {
        draggingItem = false;
        draggedItemGameObject.SetActive(false);
    }

    public void closeTooltip()
    {
        tooltip.SetActive(false);
    }

    void Start()
    {
        gold = 100;

        int slotAmount = 0;
        _allItemsInInventory = InventoryData.GetInstance();
        Debug.Log("Size of thingy: " + _allItemsInInventory.GetItemList().Count);
        database = ItemDatabase.GetInstance();

        int x = -60;
        int y = 240;
        //int a = 0;

        for (int i = 0; i < 9; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                Slots.Add(slot);

                Debug.Log(i * 4 + k);
                slot.GetComponent<SlotScript>().item = _allItemsInInventory.GetItemList()[i * 4 + k];
                
                slot.transform.parent = this.gameObject.transform;
                slot.name = "Slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);

                x += 70;

                if (k == 3)
                {
                    x = -60;
                    y -= 70;
                }
                slotAmount++;
            }
        }
        

        //addItem("Shiny Armor");
        //addItem("Gold Armor");
        //addItem("What Helmet");
        //addItem("Godly Sword Maybe");
        //addItem("Poking Helmet");
        //addItem("Blood Potion");
        //addItem("Blood Potion");
    }

    public void CheckIfItemExist(int itemID, Item item)
    {
        /*for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemID == itemID)
            {
                Items[i].itemStack = Items[i].itemStack + item.itemStack;
                break;
            }
            else if (i == Items.Count - 1)
            {
                addItemAtEmptySlot(item);
            }
        }*/
    }

    public void CheckIfItemExist(string itemName, Item item)
    {
        /*for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == itemName)
            {
                Items[i].itemStack = Items[i].itemStack + item.itemStack;
                break;
            }
            else if (i == Items.Count - 1)
            {
                addItemAtEmptySlot(item);
            }
        }*/
    }

    public void addExistingItem(Item item)
    {
        if (item.itemType == Item.ItemType.Consumable)
        {
            CheckIfItemExist(item.itemID, item);
        }
        else
        {
            addItemAtEmptySlot(item);
        }
    }

    void addItem()
    {
        //for (int i = 0; i < _allItemsInInventory.Get.Count; i++)
        {
            //Item item = _allItemsInInventory.inventoryItemList[i];
            //if (_allItemsInInventory.inventoryItemList[i].itemType == Item.ItemType.Consumable)
            //{
            //    for (int x = 0; i < Slots.Count; ++i)
            //    {
            //        if (item.itemID == Slots[i].)
            //    }
            //}
            //if (database.items[i].itemID == id)
            //{
            //    Item item = database.items[i];

            //    if (database.items[i].itemType == Item.ItemType.Consumable)
            //    {
            //        CheckIfItemExist(id, item);
            //        break;
            //    }
            //    else
            //    {
            //        addItemAtEmptySlot(item);
            //    }
            //}
        }
    }

    void addItem(string name)
    {
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].itemName == name)
            {
                Item item = database.items[i];

                if (database.items[i].itemType == Item.ItemType.Consumable)
                {
                    CheckIfItemExist(name, item);
                    break;
                }
                else
                {
                    addItemAtEmptySlot(item);
                }
            }
        }
    }

    void addItemAtEmptySlot(Item item)
    {
        /*for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == null)
            {
                Items[i] = item;
                break;
            }
        }*/
    }

    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public int GetGold()
    {
        return gold;
    }

    public void DisplayGoldText()
    {
        goldPanel.transform.GetChild(0).GetComponent<Text>().text = "Gold: " + GetGold().ToString();
    }
}
