using UnityEngine;
using System.Collections;

public class LoadAllConsumables : MonoBehaviour {
    SingletonConsumablesData _consumableList = SingletonConsumablesData.GetInstance();
    ItemDatabase _allItemList = ItemDatabase.GetInstance();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAllConsumableItems()
    {
        for (int i = 0; i < _allItemList.items.Count; ++i)
        {
            if (_allItemList.items[i].GetItemType() == Item.ItemType.Consumable)
            {
                _consumableList._ConsumableItemList.Add(_allItemList.items[i]); 
            }
        }

        print("Total consumables in game: " + _consumableList._ConsumableItemList.Count);
    }
}
