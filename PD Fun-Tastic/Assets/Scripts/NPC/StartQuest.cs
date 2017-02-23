using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartQuest : MonoBehaviour {
    public string s_sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void QuestonClick()
    {
        SceneManager.LoadScene(s_sceneName);
    }
}
