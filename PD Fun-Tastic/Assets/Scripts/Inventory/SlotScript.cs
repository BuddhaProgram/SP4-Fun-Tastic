using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Item item;
    Image itemImage;
    public int slotNumber;
    Inventory inventory;
    Text itemAmount;

    void Start()
    {
        itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (inventory.items[slotNumber].itemType != Item.ItemType.None)
        {
            itemAmount.enabled = false;

            item = inventory.items[slotNumber];
            itemImage.enabled = true;
            itemImage.sprite = item.itemIcon;

            if (inventory.items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text = "" + inventory.items[slotNumber].itemStack;
            }
        }
        else
        {
            itemImage.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            if (!inventory.draggingItem)
            {
                if (inventory.items[slotNumber].itemName != null)
                {
                    inventory.showDraggedItem(inventory.items[slotNumber], slotNumber);
                    inventory.items[slotNumber] = new Item();

                    itemAmount.enabled = false;
                }
            }
            else
            {
                if (inventory.items[slotNumber].itemType == Item.ItemType.None && inventory.draggingItem)
                {
                    Item temp = inventory.items[slotNumber];

                    inventory.items[slotNumber] = inventory.draggedItem;
                    inventory.draggedItem = temp;

                    inventory.closeDraggedItem();
                }
                else
                {
                    try
                    {
                        if (inventory.draggingItem)
                        {
                            if (inventory.items[slotNumber].itemName != null)
                            {
                                inventory.items[inventory.indexOfDraggedItem] = inventory.items[slotNumber];
                                inventory.items[slotNumber] = inventory.draggedItem;
                                inventory.closeDraggedItem();
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        //if (data.button == PointerEventData.InputButton.Right)
        //{
        //    if (inventory.items[slotNumber].itemType == Item.ItemType.Consumable)
        //    {
        //        inventory.items[slotNumber].itemstack--;

        //        if (inventory.items[slotNumber].itemstack == 0)
        //        {
        //            inventory.items[slotNumber] = new Item();
        //            itemAmount.enabled = false;
        //            inventory.closeTooltip();
        //        }
        //    }
        //}
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.items[slotNumber].itemName != null && !inventory.draggingItem)
        {
            inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.items[slotNumber]);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.items[slotNumber].itemName != null)
        {
            inventory.closeTooltip();
        }
    }
}