using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonTalkToNPC : MonoBehaviour {
    public GameObject _NPCQuest;
    public GameObject _NPCItem;
    public GameObject _Player;
    public Button _talkToNPCButton;
    public float f_distanceCheck;
    bool b_isNearNPC;

    void Start()
    {
        b_isNearNPC = false;
    }
	
	// Update is called once per frame
	void Update () {
        NPCIsNearChecker();
	}

    public void NPCIsNearChecker()
    {
        if ((_NPCQuest.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            _talkToNPCButton.gameObject.SetActive(true);
        }

        else if ((_NPCItem.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            _talkToNPCButton.gameObject.SetActive(true);
        }

        else 
        {
            _talkToNPCButton.gameObject.SetActive(false);
        }
    }

    public void NPCToTalkTo()
    {
        if ((_NPCQuest.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            b_isNearNPC = true;
            StartConversation _npcConvo = _NPCQuest.GetComponent<StartConversation>();
            _NPCQuest.GetComponent<StartConversation>().OpenConversationDialog();
        }

        else if ((_NPCItem.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
        {
            b_isNearNPC = true;
            StartConversation _npcConvo = _NPCItem.GetComponent<StartConversation>();
            _NPCItem.GetComponent<StartConversation>().OpenConversationDialog();
        }
    }

    public void NPCToCloseConvo()
    {
        if (b_isNearNPC)
        {
            if ((_NPCQuest.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
            {
                b_isNearNPC = false;
                StartConversation _npcConvo = _NPCQuest.GetComponent<StartConversation>();
                _NPCQuest.GetComponent<StartConversation>().CloseConversationDialog();
            }

            else if ((_NPCItem.transform.position - _Player.transform.position).sqrMagnitude < f_distanceCheck * f_distanceCheck)
            {
                b_isNearNPC = false;
                StartConversation _npcConvo = _NPCItem.GetComponent<StartConversation>();
                _NPCItem.GetComponent<StartConversation>().CloseConversationDialog();
            }
        }
    }
}
