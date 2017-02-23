using UnityEngine;
using System.Collections;

public class GetItems : MonoBehaviour {
    ItemDatabase _itemListInstance = ItemDatabase.GetInstance();

	void Start () {
	
	}
	
	void Update () {
	
	}

    Item GetItemByID(int ID)
    {
        for (int i = 0; i < _itemListInstance.items.Count; ++i)
        {
            if (_itemListInstance.items[i].GetItemID() == ID)
            {
                return _itemListInstance.items[i];
            }
        }

        return null;
    }

    Item GetItemByType(Item.ItemType type)
    {
        for (int i = 0; i < _itemListInstance.items.Count; ++i)
        {
            if (_itemListInstance.items[i].GetItemType() == type)
            {
                return _itemListInstance.items[i];
            }
        }

        return null; 
    }

}
