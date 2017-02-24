using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class DisplayAllConsumables : MonoBehaviour {
    SingletonConsumablesData _allConsumableItems = SingletonConsumablesData.GetInstance();
    List<Item> _DisplayConsumableInShop = new List<Item>();
    int[] i_randomConsumableItems = new int[10]; //Make sure not larger than consumable list size or you will infinite while loop and universe explodes.

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //PurchaseItemFromShop();
	}

    public int GetDisplayedConsumableCount()
    {
        return _DisplayConsumableInShop.Count;
    }

    public List<Item> GetDisplayConsumablesInShop()
    {
        return _DisplayConsumableInShop;
    }

    public void LoadToShopList()
    {
        // Makes sure the list is empty before adding it and display in the shop
        //_DisplayConsumableInShop.Clear();

        //This is to store the indexes of the items we've already chosen.
        for (int i = 0; i < i_randomConsumableItems.Length; ++i) //If it is -1, then I haven't chosen an item yet. Because index can never be -1.
        {
            i_randomConsumableItems[i] = -1;
        }

        //This is srand.
        System.Random _rand = new System.Random();

        for (int i_alreadyChosen = 0; i_alreadyChosen < i_randomConsumableItems.Length; ++i_alreadyChosen)
        {
            //We randomly select and item.
            int randomItemIndex = _rand.Next(0, _allConsumableItems._ConsumableItemList.Count);
            bool b_noDuplicate = true;

            do
            {
                b_noDuplicate = true;
                randomItemIndex = _rand.Next(0, _allConsumableItems._ConsumableItemList.Count);
                for (int i_duplicate = 0; i_duplicate < i_randomConsumableItems.Length; ++i_duplicate)
                {
                    if (i_randomConsumableItems[i_duplicate] == randomItemIndex)
                    {
                        b_noDuplicate = false;
                        break;
                    }
                }
            }
            while (b_noDuplicate == false);

            i_randomConsumableItems[i_alreadyChosen] = randomItemIndex;
            _DisplayConsumableInShop.Add(_allConsumableItems._ConsumableItemList[randomItemIndex]);
        }

        print("Total consumables in store: " + _DisplayConsumableInShop.Count);
    }
}
