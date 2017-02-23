using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hotbar : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public Item item;
    public Inventory inventory;
    public CharacterSlot characterSlot;

	void Start ()
    {
	}
	
	void Update ()
    {

        item = characterSlot.GetComponent<CharacterSlot>().item;
	    if (item.itemType != Item.ItemType.None)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
	}

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            if (item.itemType != Item.ItemType.None)
            {
                Item temp = item;
                item = inventory.draggedItem;
                inventory.draggedItem = temp;
                inventory.showDraggedItem(temp, -1);

                characterSlot.GetComponent<CharacterSlot>().item = item;
            }
            else
            {
                if (index == 0 && inventory.draggedItem.itemType == Item.ItemType.Head)
                {
                    if (item.itemType != Item.ItemType.None)
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.showDraggedItem(temp, -1);

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                    else
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.closeDraggedItem();

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                }
                if (index == 1 && inventory.draggedItem.itemType == Item.ItemType.Body)
                {
                    if (item.itemType != Item.ItemType.None)
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.showDraggedItem(temp, -1);

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                    else
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.closeDraggedItem();

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                }
                if (index == 2 && inventory.draggedItem.itemType == Item.ItemType.Leg)
                {
                    if (item.itemType != Item.ItemType.None)
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.showDraggedItem(temp, -1);

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                    else
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.closeDraggedItem();

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                }
                if (index == 3 && inventory.draggedItem.itemType == Item.ItemType.Weapon)
                {
                    if (item.itemType != Item.ItemType.None)
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.showDraggedItem(temp, -1);

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                    else
                    {
                        Item temp = item;
                        item = inventory.draggedItem;
                        inventory.draggedItem = temp;
                        inventory.closeDraggedItem();

                        characterSlot.GetComponent<CharacterSlot>().item = item;
                    }
                }
            }
        }
    }
}