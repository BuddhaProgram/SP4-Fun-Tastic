using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AllQuestData : MonoBehaviour
{
    SingletonQuestData _instance = SingletonQuestData.GetInstance();
    public string s_sceneName;
    public string s_questName;

    public void Start()
    {

    }

    public void Update()
    {
        RequirementIsDone();
    }

    public void AddQuestToDictionary(string s_questName, int i_requirement)
    {
        if (_instance.QuestChecker.ContainsKey(s_questName) == false)
        {
            _instance.QuestChecker.Add(s_questName, i_requirement);
        }
    }

    public void RequirementIsDone()
    {
        if (_instance.QuestChecker.ContainsKey(s_questName) == true)
        {
            int i_outValue;
            if (_instance.QuestChecker.TryGetValue(s_questName, out i_outValue) == true)
            {
                if (i_outValue <= 0)
                {
                    SceneManager.LoadScene(s_sceneName);
                }
            }
        }
    }
}