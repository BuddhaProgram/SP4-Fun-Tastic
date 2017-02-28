using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadConsumablesToShop : MonoBehaviour
{
    ItemDatabase _allConsumableItems = ItemDatabase.GetInstance();
    List<Item> _ConsumableListInShop;
    int[] i_randomConsumableItems = new int[10]; //Make sure not larger than consumable list size or you will infinite while loop and universe explodes.

    // Use this for initialization
    void Start()
    {
        RandomizedShopList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomizedShopList()
    {
        List<Item> tempItemList = _allConsumableItems.GetConsumableList();
        int i_totalConsumables = _allConsumableItems.GetConsumableList().Count;
        _ConsumableListInShop = new List<Item>();
        // Makes sure the list is empty before adding it and display in the shop
        //_ConsumableListInShop.Clear();

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
            int randomItemIndex = _rand.Next(0, i_totalConsumables);
            bool b_noDuplicate = true;

            do
            {
                b_noDuplicate = true;
                randomItemIndex = _rand.Next(0, i_totalConsumables);
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
            _ConsumableListInShop.Add(tempItemList[randomItemIndex]);
        }
    }

    public List<Item> GetShopList()
    {
        return _ConsumableListInShop;
    }
}
