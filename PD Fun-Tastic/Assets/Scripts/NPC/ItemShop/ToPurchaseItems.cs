using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ToPurchaseItems : MonoBehaviour {
    public GameObject _LoadedItemsInShop;
    InventoryData Inventory = InventoryData.GetInstance();
    InventoryData _InventoryListInstance = InventoryData.GetInstance();
    public int i_getItemIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickToPurchase()
    {
        string s_purchasedItemName = _LoadedItemsInShop.GetComponent<DisplayAllConsumables>().GetDisplayConsumablesInShop()[i_getItemIndex].itemName;
        _InventoryListInstance.AddItem(s_purchasedItemName);
        print(_InventoryListInstance.GetItemList().Count);
        //print(_InventoryListInstance.inventoryItemList.Count);
        //print(s_purchasedItemName.itemName);
    }
}
