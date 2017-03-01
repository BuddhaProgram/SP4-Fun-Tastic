using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayConsumablesInShop : SpecificNPC {
    public Text[] _nameItem;
    public Text[] _descriptionItem;
    public Text[] _costItem;
    public Image[] _itemImage;
    public GameObject GetLoadedItems;

    public void DisplayConsumables()
    {
        List<Item> tempItemList = GetLoadedItems.gameObject.GetComponent<LoadConsumablesToShop>().GetShopList();
        print(tempItemList.Count);
        for (int i = 0; i < 10; ++i)
        {
            _nameItem[i].GetComponent<Text>().text = GetLoadedItems.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemName;
            _descriptionItem[i].GetComponent<Text>().text = GetLoadedItems.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemDesc;
            _costItem[i].GetComponent<Text>().text = GetLoadedItems.GetComponent<LoadConsumablesToShop>().GetShopList()[i].buyValue.ToString();
            _itemImage[i].GetComponent<Image>().sprite = GetLoadedItems.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemIcon;
        }
    }

    public override void DoStuffS()
    {
        DisplayConsumables();
    }

    public override void Exit()
    {
        
    }
}
