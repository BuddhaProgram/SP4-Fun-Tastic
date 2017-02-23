using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class StartConversation : MonoBehaviour {

    public string s_convoFileName;

    //public Text _displayConversation;
    List<string> _loadConversationList = new List<string>();
    public Text _instanceText;
    public Canvas _setCanvas;
    GameObject _displayConversationText;

	// Use this for initialization
	void Start () {
        LoadConversationFile(s_convoFileName);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void LoadConversationFile(string filename)
    {
        try
        {
            StreamReader theReader = new StreamReader(filename, Encoding.Default);
            using (theReader)
            {
                string s_line = null;
                do
                {
                    s_line = theReader.ReadLine();
                    if (s_line != null)
                    {
                        s_line = s_line + '\n';
                        _loadConversationList.Add(s_line);
                    }
                }
                while (s_line != null);
                theReader.Close();
            }
        }

        catch (DirectoryNotFoundException)
        {
        }
    }

    public void OpenConversationDialog()
    {
            string s_paragraph = "";
            _displayConversationText = GameObject.Instantiate(_instanceText.gameObject);

            _setCanvas.gameObject.SetActive(true);
            _displayConversationText.GetComponent<Transform>().SetParent(_setCanvas.gameObject.GetComponent<Transform>());
            _displayConversationText.GetComponent<Transform>().localPosition = new Vector3(0, -500, 0);
            _displayConversationText.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);

            foreach (string s_eachLine in _loadConversationList)
            {
                if (s_eachLine != null)
                {
                    s_paragraph += s_eachLine;
                }
            }

        _displayConversationText.GetComponent<Text>().text = s_paragraph;
        this.GetComponent<SpecificNPC>().DoStuffS();
    }

    public void CloseConversationDialog()
    {
        Destroy(_displayConversationText);
        _setCanvas.gameObject.SetActive(false);
        this.GetComponent<SpecificNPC>().Exit();
    }
}
