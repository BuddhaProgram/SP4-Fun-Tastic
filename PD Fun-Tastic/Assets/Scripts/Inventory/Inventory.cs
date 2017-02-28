using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public SlotScript slotPrefab;
    public List<SlotScript> slotList;

    public Canvas inventoryCanvas;

    public Image draggedImage;
	// Use this for initialization
	void Start () {

        draggedImage.enabled = false;
        slotList = new List<SlotScript>();
        const int inventorySize = 27;
        for (int i = 0; i < inventorySize; ++i)
        {
            SlotScript temp = Instantiate(slotPrefab);
            float xPos = 0f;
            //hardcode best code?
            if (i % 3 == 0)
            {
                xPos = -75;

            }
            else if (i % 3 == 1)
            {
                xPos = 0f;
            }

            else
            {
                xPos = 75;
            }


            temp.transform.localPosition = new Vector3(xPos + 125,390 - (i/3)*70,0);
            //Set which slot in the inventory data to refer to
            temp.index = i;
            slotList.Add(temp);
            //set parent
            temp.transform.parent = this.transform;

        }

	}
	
	// Update is called once per frame
	void Update () {
        Item draggedItem =InventoryData.GetInstance().draggedItem;

        if (draggedItem != null)
        {
            //Debug.Log("hi");
            draggedImage.enabled = true;
            draggedImage.sprite = draggedItem.itemIcon;

            Vector2 mousePos = Input.mousePosition;

            mousePos.x -= Screen.width/2f - 20;
            mousePos.y -= Screen.height/2f;

            draggedImage.transform.localPosition = mousePos;
           

        }
        else 
        {
            draggedImage.enabled = false;
        }
        
	}

    public void Close()
    {
        InventoryData.GetInstance().CloseInventory();
        draggedImage.enabled = false;
    }
}
