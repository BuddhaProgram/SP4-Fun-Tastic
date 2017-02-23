using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class TalkToNPC : MonoBehaviour{
    public GameObject _NPCQuest;
    public GameObject _NPCItem;
    public GameObject _NPCWeapon;
    public GameObject _Player;
    public float f_distanceCheck;

    bool b_isNearNPC;
    void Start() {
        b_isNearNPC = false;
    }

    void Update() {
        NPCIsNear();
    }

    public void NPCIsNear()
    {
        if ((_NPCQuest.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            if (Input.GetButtonDown("TalkNPC") && b_isNearNPC == false)
            {
                b_isNearNPC = true;
                StartConversation _npcConvo = _NPCQuest.GetComponent<StartConversation>();
                _NPCQuest.GetComponent<StartConversation>().OpenConversationDialog();
            }

            else if (Input.GetButtonDown("TalkNPC") && b_isNearNPC == true)
            {
                b_isNearNPC = false;
                StartConversation _npcConvo = _NPCQuest.GetComponent<StartConversation>();
                _NPCQuest.GetComponent<StartConversation>().CloseConversationDialog();
            }
        }

        else if ((_NPCItem.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            if (Input.GetButtonDown("TalkNPC") && b_isNearNPC == false)
            {
                b_isNearNPC = true;
                StartConversation _npcConvo = _NPCItem.GetComponent<StartConversation>();
                _NPCItem.GetComponent<StartConversation>().OpenConversationDialog();
            }

            else if (Input.GetButtonDown("TalkNPC") && b_isNearNPC == true)
            {
                b_isNearNPC = false;
                StartConversation _npcConvo = _NPCItem.GetComponent<StartConversation>();
                _NPCItem.GetComponent<StartConversation>().CloseConversationDialog();
            }
        }

        else
        {
            if (b_isNearNPC == true)
            {
                b_isNearNPC = false;
            }
        }
    }
}
