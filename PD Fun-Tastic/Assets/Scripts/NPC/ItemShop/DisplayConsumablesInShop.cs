using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisplayConsumablesInShop : SpecificNPC {
    public Text[] _consumableName;
    public Text[] _consumableDescription;
    public Image[] _consumableImage;
    public GameObject GetLoadedConsumables;

    public void DisplayConsumables()
    {
        List<Item> tempItemList = GetLoadedConsumables.gameObject.GetComponent<LoadConsumablesToShop>().GetShopList();
        print(tempItemList.Count);
        for (int i = 0; i < 10; ++i)
        {
            _consumableName[i].GetComponent<Text>().text = GetLoadedConsumables.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemName;
            _consumableDescription[i].GetComponent<Text>().text = GetLoadedConsumables.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemDesc;
            _consumableImage[i].GetComponent<Image>().sprite = GetLoadedConsumables.GetComponent<LoadConsumablesToShop>().GetShopList()[i].itemIcon;
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
