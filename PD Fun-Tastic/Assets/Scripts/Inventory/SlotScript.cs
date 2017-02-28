using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour ,IPointerClickHandler{

    public int index;
    public Item storedItem = null;
    //what was this for again? cant rmb
    public Image iconImage;

	// Use this for initialization
	void Start () {

        storedItem = InventoryData.GetInstance().GetSlotItem(index);

 
	}
	
	// Update is called once per frame
	void Update () {
        storedItem = InventoryData.GetInstance().GetSlotItem(index);

        if (storedItem != null)
        {
            iconImage.sprite = storedItem.itemIcon;
            iconImage.enabled = true;
           
        }
        else {
            iconImage.enabled = false;
        }
        

	}

    public void PlaceItem(Item item)
    {
        InventoryData.GetInstance().ChangeSlotItem(this.index, item);
        storedItem = item;
    }

    public void OnPointerClick(PointerEventData data)
    {
        //check if its left clicked
        if (data.button == PointerEventData.InputButton.Left)
        {
            //swap the items
            Item temp = storedItem;
            PlaceItem(InventoryData.GetInstance().draggedItem);
            InventoryData.GetInstance().draggedItem = temp;

            //Debug.Log("CLICKED");
        }
    }


}
