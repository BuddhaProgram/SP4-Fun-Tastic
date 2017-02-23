using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class LoadQuestOnScene : MonoBehaviour {
    SingletonQuestData _instance = SingletonQuestData.GetInstance();
    public string s_fileName;
    public Text[] _displayQuestDescription;

    List<string> _questNames = new List<string>();
    List<int> _questRequirements = new List<int>();
    List<string> _loadAllQuestDescription = new List<string>();
	// Use this for initialization
	void Start () {
        LoadQuestDescriptionFile();
        for (int i = 0; i < _questNames.Count; ++i)
        {
            if (_instance.QuestChecker.ContainsKey(_questNames[i]) == false)
            {
                _instance.QuestChecker.Add(_questNames[i], _questRequirements[i]);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadQuestDescriptionFile()
    {
        try
        {
            StreamReader theReader = new StreamReader(s_fileName, Encoding.Default);
            using (theReader)
            {
                string s_line = null;
                string s_paragraph = null;
                do
                {
                    s_line = theReader.ReadLine();
                    if (s_line != null)
                    {
                        if (s_line.Contains("*") == true)
                        {
                            string s_questName = s_line.Substring(1);
                            _questNames.Add(s_questName);
                        }

                        else if (s_line.Contains("&") == true)
                        {
                            int i_questRequirements = int.Parse(s_line.Substring(1));
                            _questRequirements.Add(i_questRequirements);
                        }

                        else
                        {
                            if (s_line.Contains("End") == false)
                            {
                                s_paragraph += s_line + '\n';
                            }

                            else
                            {
                                _loadAllQuestDescription.Add(s_paragraph);
                                s_paragraph = "";
                            }
                        }
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

    public void AddTextOnUI()
    {
        if (_loadAllQuestDescription.Count > 0)
        {
            for (int i = 0; i < _loadAllQuestDescription.Count; ++i)
            {
                _displayQuestDescription[i].GetComponent<Text>().text = _loadAllQuestDescription[i];
            }
        }
    }
}