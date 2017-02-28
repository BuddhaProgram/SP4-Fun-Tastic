using UnityEngine;
using System.Collections;

public class EnemyReductionChecker : MonoBehaviour {
    QuestData _instance = QuestData.GetInstance();
    public string s_questName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void EnemyRequirementChecker()
    {
        _instance.MinusRequirementValue();
    }
}
