using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AllQuestData : MonoBehaviour
{
    QuestData _instance = QuestData.GetInstance();
    public string s_sceneName;
    public string s_questName;

    public void Start()
    {

    }

    public void Update()
    {
        RequirementIsDone();
    }

    //public void AddQuestToDictionary(string s_questName, int i_requirement)
    //{
    //    if (_instance.QuestChecker.ContainsKey(s_questName) == false)
    //    {
    //        _instance.QuestChecker.Add(s_questName, i_requirement);
    //    }
    //}

    public void RequirementIsDone()
    {
        if (_instance.CheckQuestExistInDictionary(s_questName) == true)
        {
            if (_instance.GetQuestRequirement() <= 0)
            {
                SceneManager.LoadScene(s_sceneName);
            }
        }
    }
}