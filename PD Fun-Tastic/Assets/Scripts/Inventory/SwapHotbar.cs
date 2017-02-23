using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwapHotbar : MonoBehaviour {

    public Item item;
    public Inventory inventory;
    public GameObject primaryHotbar;
    public GameObject secondaryHotbar;

    private Hotbar[] primary;
    private HotbarSecondary[] secondary;

	public void SwapHotbarItem()
    {
        primary = primaryHotbar.GetComponentsInChildren<Hotbar>();
        secondary = secondaryHotbar.GetComponentsInChildren<HotbarSecondary>();

        // Switch Primary and Secondary Helmet
        Item temp = primary[0].item;
        primary[0].item = secondary[0].item;
        primary[0].characterSlot.item = secondary[0].item;
        secondary[0].item = temp;

        // Switch Primary and Secondary Body
        Item temp2 = primary[1].item;
        primary[1].item = secondary[1].item;
        primary[1].characterSlot.item = secondary[1].item;
        secondary[1].item = temp2;

        // Switch Primary and Secondary Leg
        Item temp3 = primary[2].item;
        primary[2].item = secondary[2].item;
        primary[2].characterSlot.item = secondary[2].item;
        secondary[2].item = temp3;

        // Switch Primary and Secondary Weapon
        Item temp4 = primary[3].item;
        primary[3].item = secondary[3].item;
        primary[3].characterSlot.item = secondary[3].item;
        secondary[3].item = temp4;
    }
}