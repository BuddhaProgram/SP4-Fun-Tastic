using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class QuestDescription : SpecificNPC {
    SingletonQuestData _instance = SingletonQuestData.GetInstance();
    public GameObject _LoadedQuestDescription;



    public override void DoStuffS()
    {
        _LoadedQuestDescription.GetComponent<LoadQuestOnScene>().AddTextOnUI();

    }

    public override void Exit()
    {

    }
}
