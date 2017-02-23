using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonConsumablesData {
    private static SingletonConsumablesData _allConsumables = null;
    public List<Item> _ConsumableItemList = new List<Item>();

    public static SingletonConsumablesData GetInstance()
    {
        if (_allConsumables == null)
        {
            _allConsumables = new SingletonConsumablesData();
        }

        return _allConsumables;
    }
}
