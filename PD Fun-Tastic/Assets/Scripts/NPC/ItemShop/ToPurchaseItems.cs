using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ToPurchaseItems : MonoBehaviour {
    InventoryData _inventoryData = InventoryData.GetInstance();
    public Button _clickToPurchaseButton;
    public GameObject _loadedItemList;
    public int i_getItemIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickToPurchase()
    {
        Item tempItem = _loadedItemList.gameObject.GetComponent<LoadConsumablesToShop>().GetShopList()[i_getItemIndex];
        _inventoryData.AddItemToInventory(tempItem.itemName);
        print(tempItem.itemName);
    }
}
