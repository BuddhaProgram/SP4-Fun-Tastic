using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ItemType
{
    None,
    Weapon,
    Head,
    Body,
    Leg,
    Consumable
}
[CreateAssetMenu(menuName = "Items")]
public class Item:ScriptableObject
{
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;
    public int atk;
    public int vit;
    public int agi;
    public ItemType itemType;
    public Abilities ability;
    public int buyValue;
    public int sellValue;
}
