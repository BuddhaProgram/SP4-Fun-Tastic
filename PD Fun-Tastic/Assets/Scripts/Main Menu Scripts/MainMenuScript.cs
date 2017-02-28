using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
    public GameObject _MainMenuPanel;
    public GameObject _WarningPopupPanel;
    public string s_sceneName;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckHasSaveFile()
    {
        if (PlayerPrefsX.GetBool("Player") == false)
        {
            _MainMenuPanel.SetActive(false);
            _WarningPopupPanel.SetActive(true);
            //_MainMenuCanvas.gameObject.SetActive(false);
            //_WarningPopupCanvas.gameObject.SetActive(true);
        }

        else
        {
            print("Erase all data");
            //SceneManager.LoadScene(s_sceneName);
        }
    }

    public void LoadNewGame()
    {
        print("New game called");
        SceneManager.LoadScene(s_sceneName);
    }

    public void LoadContinueGame()
    {
        print("Continue game called");
        //SceneManager.LoadScene(s_sceneName);
    }

    public void BackToMainMenu()
    {
        _WarningPopupPanel.SetActive(false);
        _MainMenuPanel.SetActive(true);
    }
}
