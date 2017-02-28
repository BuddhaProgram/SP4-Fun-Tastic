using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartQuest : MonoBehaviour {
    public string s_sceneName;
    public string s_questName;
    QuestData _questData = QuestData.GetInstance();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void QuestonClick()
    {
        _questData.SetQuestRequirementValue(s_questName);
        SceneManager.LoadScene(s_sceneName);
    }
}
