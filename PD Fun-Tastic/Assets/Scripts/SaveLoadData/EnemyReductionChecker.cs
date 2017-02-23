using UnityEngine;
using System.Collections;

public class EnemyReductionChecker : MonoBehaviour {
    SingletonQuestData _instance = SingletonQuestData.GetInstance();
    public string s_questName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetValueToDictionary()
    {
        if (_instance.QuestChecker.ContainsKey(s_questName) == true)
        {
            int i_value;
            i_value = _instance.QuestChecker[s_questName];
            i_value--;
            print(i_value);
            if (i_value < 0)
            {
                i_value = 0;
            }
            _instance.QuestChecker[s_questName] = i_value;
        }

    }
}
