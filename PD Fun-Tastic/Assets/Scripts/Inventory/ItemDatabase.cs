using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase
{
    private static ItemDatabase instance = null;

    public static ItemDatabase GetInstance()
    {
        if (instance == null)
        {
            instance = new ItemDatabase();
            instance.Start();
        }
        return instance;
    }

    public List<Item> items = new List<Item>();

    void Start()
    {
        //items.Add(new Item("Nooblord's Sword", 0, 1, 3 ,0,1, Item.ItemType.Weapon, "Basic Ability", "A sword wrapped in a gooey, green kinda slime. The chipped blade makes it very unappetising."));
        //items.Add(new Item("Shark Attack Sword", 1, 5,1,0, 1, Item.ItemType.Weapon, "Basic Ability", "The triangle head makes it looks like a shark. Shark Attack!"));
        //items.Add(new Item("Godly Sword Maybe", 2, 10, 2, 10, 1, Item.ItemType.Weapon, "Lightning Ball", "Some kinda lightning, laser shooting, godly sword. Maybe."));
        //items.Add(new Item("Blood Potion", 3, 0,0,0, 1, Item.ItemType.Consumable, "Basic Ability", "Red liquid that looks like blood. Doesn't it makes you a vampire if you drink it?"));

        //items.Add(new Item("What Helmet", 4, 0,3,0, 1, Item.ItemType.Head, "Fire Ball", "Helmet that doesn't even look like a helmet. What kind of protection is this?"));
        //items.Add(new Item("Headbutt Helmet", 5, 0,5,0, 1, Item.ItemType.Head, "Basic Ability", "Maybe you could use this to headbutt someone...in the butt."));
        //items.Add(new Item("Poking Helmet", 6,3,3,0, 1, Item.ItemType.Head, "Basic Ability", "The ultimate helmet that can even poke your shoulders. Definitely godly."));
        //items.Add(new Item("Random Banana", 7, 0,0,0, 1, Item.ItemType.Consumable, "Basic Ability", "Oh look, it's just a random banana."));

        //items.Add(new Item("Shiny Armor", 8, 0,10,0 ,1, Item.ItemType.Body, "Fire Ball", "Just an ordinary armor covered in silver paint"));
        //items.Add(new Item("Gold Armor", 9, 0,15,0 ,1, Item.ItemType.Body, "Basic Ability", "Literally made out of Gold, must be really really heavy"));
        //items.Add(new Item("Fiery God Armor", 10, 10,15,10 ,1, Item.ItemType.Body, "Basic Ability", "Some say this armor burns brightly in the dark, while some say it burns the wearer."));
        //items.Add(new Item("Eye", 11, 0,0,0, 1, Item.ItemType.Consumable, "Basic Ability", "A delicious eyeball that gives awesome stats when eaten. Looks totally tasty! Oh, it blinked."));

        //items.Add(new Item("Cheap Wood Shoe", 12, 0,2,0 ,1, Item.ItemType.Leg, "Basic Ability", "Cheap, wooden shoe that doesn't exactly give protection and instead hurts you"));
        //items.Add(new Item("Iron Wood Shoe", 13, 5,5,0, 1, Item.ItemType.Leg, "Basic Ability", "Upgraded from the Cheap Wood Shoe, now with Iron and more pain!"));
        //items.Add(new Item("Mysterious Shoe", 14, 10,10,10, 1, Item.ItemType.Leg, "Basic Ability", "Mysterious shoe with a cloud symbol on it...Oooooo"));
        //items.Add(new Item("Bone", 15, 0,0,0, 1, Item.ItemType.Consumable, "Basic Ability", "Bone that can be eaten. Must be nice?"));

    }
}