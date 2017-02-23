using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonQuestData {
    private static SingletonQuestData _questInstance = null;
    public Dictionary<string, int> QuestChecker = new Dictionary<string, int>();


    public static SingletonQuestData GetInstance()
    {
        if (_questInstance == null)
        {
            _questInstance = new SingletonQuestData();
        }

        return _questInstance;
    }
	
}
