using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour {
    public GameObject _MainMenuPanel;
    public GameObject _WarningPopupPanel;
    InventoryData _GetInventoryFromKey = InventoryData.GetInstance();
    string[] _allItemNames;

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
        if (PlayerPrefsX.GetBool("Inventory") == true)
        {
            _MainMenuPanel.SetActive(false);
            _WarningPopupPanel.SetActive(true);
            //_MainMenuCanvas.gameObject.SetActive(false);
            //_WarningPopupCanvas.gameObject.SetActive(true);
        }

        else
        {
            print("Erase all data");
            LoadNewGame();
        }
    }

    public void LoadNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadContinueGame()
    {
        if (PlayerPrefs.HasKey("Inventory") == true)
        {
            _allItemNames = PlayerPrefsX.GetStringArray("Inventory");

            for (int i = 0; i < _allItemNames.Length; ++i)
            {
                _GetInventoryFromKey.AddItemToInventory(_allItemNames[i]);
            }
            print("Continue game called");
            SceneManager.LoadScene(s_sceneName);
        }
    }

    public void BackToMainMenu()
    {
        _WarningPopupPanel.SetActive(false);
        _MainMenuPanel.SetActive(true);
    }
}
