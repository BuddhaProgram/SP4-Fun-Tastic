using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EquipmentSlot : MonoBehaviour,IPointerClickHandler {

    

    public ItemType slotType;

    public Item storedItem;

    public Image itemIcon;

	// Use this for initialization
	void Start () {
        storedItem = InventoryData.GetInstance().GetEquipment(slotType);

        if (storedItem != null)
        {
            itemIcon.sprite = storedItem.itemIcon;
            itemIcon.enabled = true;

        }
        else
        {
            itemIcon.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

        storedItem = InventoryData.GetInstance().GetEquipment(slotType);

        if (storedItem != null)
        {
            itemIcon.sprite = storedItem.itemIcon;
            itemIcon.enabled = true;

        }
        else
        {
            itemIcon.enabled = false;
        }
     
	}

    public void PlaceItem(Item item)
    {
        InventoryData.GetInstance().ChangeEquipment(slotType, item);
        storedItem = item;
    }

    public void OnPointerClick(PointerEventData data)
    {
        //check if its left clicked
        if (data.button == PointerEventData.InputButton.Left)
        {
            if (InventoryData.GetInstance().draggedItem == null)
            {
                //swap the items
                Item temp = storedItem;
                PlaceItem(InventoryData.GetInstance().draggedItem);
                InventoryData.GetInstance().draggedItem = temp;
            }
            
             else if (InventoryData.GetInstance().draggedItem.itemType == slotType)
            { 
                //swap the items
                Item temp = storedItem;
                PlaceItem(InventoryData.GetInstance().draggedItem);
                InventoryData.GetInstance().draggedItem = temp;
            }
            //Debug.Log("CLICKED");
        }
    }
}
