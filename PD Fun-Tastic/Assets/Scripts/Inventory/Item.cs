using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]

public class Item
{
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public string itemAbility;
    public int atk;
    public int vit;
    public int agi;
    public int itemStack;
    public ItemType itemType;
    public Abilities ability;

    public enum ItemType
    {
        None,
        Weapon,
        Head,
        Body,
        Leg,
        Consumable
    }

    public Item(string name, int id,  int atk, int vit,int agi,int stackAmt, ItemType type,string ability,string desc)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemAbility = ability;
        this.atk = atk;
        this.vit = vit;
        this.agi = agi;
        itemStack = stackAmt;
        itemType = type;
        itemIcon = Resources.Load<Sprite>("Item Images/" + name);
        string filepath = "Scriptable Objects/Abilities/" + ability;
        this.ability = AbilityDataBase.GetInstance().GetAbility(ability);
        //this.ability = Resources.Load<Abilities>(filepath + ability);
        //Debug.Log("hi");
        //Debug.Log(this.ability.aName);
    }

    public Item()
    {
        //this.ability = AbilityDataBase.GetInstance().GetAbility("Scriptable Objects/Abilities/Basic Attack");
    }

    public int GetItemID()
    {
        return itemID;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

}
