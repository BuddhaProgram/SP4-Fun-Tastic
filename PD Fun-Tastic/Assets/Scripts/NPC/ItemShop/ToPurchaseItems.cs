using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ToPurchaseItems : MonoBehaviour {
    InventoryData _inventoryData = InventoryData.GetInstance();
    public Button _clickToPurchaseButton;
    public GameObject _loadedItemList;
    public GameObject _warningPanel;
    public int i_getItemIndex;
    bool b_warning;
	// Use this for initialization
	void Start () {
        b_warning = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ClickToPurchase()
    {
        Item tempItem = _loadedItemList.gameObject.GetComponent<LoadConsumablesToShop>().GetShopList()[i_getItemIndex];

        if (_inventoryData.CheckIfEnoughCurrency(tempItem.buyValue) == true && _inventoryData.AddItemToInventory(tempItem) == true)
        {
                _inventoryData.MinusCurrency(tempItem.buyValue);
                print(tempItem.itemName);
        }

        else
        {
            b_warning = true;
        }


        if (b_warning == true)
        {
            _warningPanel.gameObject.SetActive(true);
        }

        else
        {
            _warningPanel.gameObject.SetActive(false);
        }
    }

    public void ClickToReturnPrevious()
    {
        b_warning = false;
        _warningPanel.gameObject.SetActive(false);
        //if (_notEnoughCurrency.gameObject.activeSelf == true)
        ////if (b_notEnoughGold == true)
        //{
        //    b_notEnoughSlot = false;
        //    _notEnoughCurrency.gameObject.SetActive(false);
        //}
    }
}
