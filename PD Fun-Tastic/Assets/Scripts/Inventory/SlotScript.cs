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
        if (inventory.Items[slotNumber].itemName != null && inventory.Items[slotNumber].itemType != Item.ItemType.None)
        {
            itemAmount.enabled = false;

            item = inventory.Items[slotNumber];
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;

            if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text = "" + inventory.Items[slotNumber].itemStack;
            }
        }
        else if (inventory.Items[slotNumber].itemName == null)
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
                if (inventory.Items[slotNumber].itemName != null)
                {
                    inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
                    inventory.Items[slotNumber] = new Item();

                    itemAmount.enabled = false;
                }
            }
            else
            {
                if (inventory.Items[slotNumber].itemType == Item.ItemType.None && inventory.draggingItem)
                {
                    Item temp = inventory.Items[slotNumber];

                    inventory.Items[slotNumber] = inventory.draggedItem;
                    inventory.draggedItem = temp;

                    inventory.closeDraggedItem();
                }
                else
                {
                    try
                    {
                        if (inventory.draggingItem)
                        {
                            if (inventory.Items[slotNumber].itemName != null)
                            {
                                inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
                                inventory.Items[slotNumber] = inventory.draggedItem;
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

        if (data.button == PointerEventData.InputButton.Right)
        {
            if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                inventory.Items[slotNumber].itemStack--;

                if (inventory.Items[slotNumber].itemStack == 0)
                {
                    inventory.Items[slotNumber] = new Item();
                    itemAmount.enabled = false;
                    inventory.closeTooltip();
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (inventory.Items[slotNumber].itemName != null && !inventory.draggingItem)
        {
            inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            inventory.closeTooltip();
        }
    }
}