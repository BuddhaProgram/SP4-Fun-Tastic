using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestData {
    private static QuestData _questInstance = null;
    public static Dictionary<string, int> QuestChecker;
    private static int i_requirementValue;

    public static QuestData GetInstance()
    {
        if (_questInstance == null)
        {
            _questInstance = new QuestData();
            QuestChecker = new Dictionary<string, int>();
            i_requirementValue = new int();
        }

        return _questInstance;
    }

    public void SetAllQuestToDictionary(string questName, int questRequirement)
    {
        QuestChecker.Add(questName, questRequirement);
    }

    public bool CheckQuestExistInDictionary(string questName)
    {
        return QuestChecker.ContainsKey(questName);
    }

    public void SetQuestRequirementValue(string questName)
    {
        if (QuestChecker.ContainsKey(questName) == true)
        {
            i_requirementValue = QuestChecker[questName];
            Debug.Log("Quest requirement settled");
        }
    }

    public int GetQuestRequirement()
    {
        return i_requirementValue;
    }

    public void MinusRequirementValue()
    {
        i_requirementValue--;
        if (i_requirementValue < 0)
        {
            i_requirementValue = 0;
        }
    }
}
