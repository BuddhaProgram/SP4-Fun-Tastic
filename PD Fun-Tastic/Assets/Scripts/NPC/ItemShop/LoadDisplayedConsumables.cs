using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadDisplayedConsumables : SpecificNPC {
    public GameObject GetConsumableList;
    public Text[] _RenderConsumableName;
    public Text[] _RenderConsumableDescription;
    public Image[] _RenderConsumableImage;
    List<Item> _copyDisplayConsumableList = new List<Item>();

    public void GetDisplayedConsumableDescription()
    {
        _copyDisplayConsumableList = GetConsumableList.GetComponent<DisplayAllConsumables>().GetDisplayConsumablesInShop();
        int i_displayCount = GetConsumableList.GetComponent<DisplayAllConsumables>().GetDisplayedConsumableCount();

        for (int i = 0; i < i_displayCount; ++i)
        {
            _RenderConsumableName[i].GetComponent<Text>().text = _copyDisplayConsumableList[i].itemName;
            _RenderConsumableDescription[i].GetComponent<Text>().text = _copyDisplayConsumableList[i].itemDesc;
            _RenderConsumableImage[i].GetComponent<Image>().sprite = _copyDisplayConsumableList[i].itemIcon;
        }
    }

    public override void DoStuffS()
    {
        GetDisplayedConsumableDescription();
    }

    public override void Exit()
    {

    }
}
