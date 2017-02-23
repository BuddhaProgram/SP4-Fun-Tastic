using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintOutRequirementInQuest : MonoBehaviour {
    SingletonQuestData _instance = SingletonQuestData.GetInstance();
    public string s_questName;
    public Text _RenderRequirement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RenderRequirementOnSCreen();
	}

    void RenderRequirementOnSCreen()
    {
        if (_instance.QuestChecker.ContainsKey(s_questName) == true)
        {
            _RenderRequirement.GetComponent<Text>().text = _instance.QuestChecker[s_questName].ToString() + " Monster";
        }
    }
}
