using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class LoadQuestTextFile : MonoBehaviour {
    //public TextAsset QuestAsset;
    //private string QuestText;
	// Use this for initialization
    //public Image imagePrefab;
    //public Canvas canvas;
    //public Text _displayQuestLog;

    //List<string> _loadPrefabsName = new List<string>();
    //List<string> _loadQuestDetails = new List<string>();
    //public Text printout;
	void Start () {
        //QuestText = QuestAsset.text;
    
	}
	
	// Update is called once per frame
	void Update () {

	}

    //public void OpenQuestLog()
    //{
    //    if (Load("Assets\\Resources\\Test.txt") == true)
    //    {
    //        GameObject loadImage = GameObject.Instantiate(imagePrefab.gameObject);
    //        foreach (string s_tempPrefabName in _loadPrefabsName)
    //        {
    //            if (s_tempPrefabName != null)
    //            {
    //                if (s_tempPrefabName == "Image")
    //                {                       

    //                    loadImage.GetComponent<Transform>().SetParent(canvas.gameObject.GetComponent<Transform>());
    //                    loadImage.GetComponent<Transform>().position = new Vector3(170, 340, 0);

    //                    print("Opened Quest Giver List");
    //                }
    //            }

    //            else 
    //            {
    //                printout.text = "error";
    //            }
    //        }

    //        GameObject _textQuestList = GameObject.Instantiate(_displayQuestLog.gameObject);
    //        _textQuestList.GetComponent<Transform>().SetParent(canvas.gameObject.GetComponent<Transform>());
    //        _textQuestList.GetComponent<Transform>().position = loadImage.GetComponent<Transform>().position;
    //        foreach (string s_tempQuestDescription in _loadQuestDetails)
    //        {

    //            if (s_tempQuestDescription != null)
    //            {

    //                _textQuestList.GetComponent<Text>().text += s_tempQuestDescription;
    //                print("Opened Quest Giver List");
    //            }

    //        }
    //    }
    //}

    //public bool Load(string fileName)
    //{
    //    try
    //    {
    //        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
    //        using (theReader)
    //        {
    //            string s_line = null;
    //            string s_prefabName = null;
    //            string s_questDescription = null;
    //            do
    //            {
    //                s_line = theReader.ReadLine();


    //                if (s_line != null)
    //                {
    //                    if (s_line.Contains("-") == true)
    //                    {
    //                        s_prefabName = s_line.Substring(1);
    //                        _loadPrefabsName.Add(s_prefabName);
    //                    }

    //                    else 
    //                    {
    //                        s_questDescription = s_line + '\n';
    //                        _loadQuestDetails.Add(s_questDescription);
    //                    }

    //                }
    //            }
    //            while (s_line != null);
    //            theReader.Close();
    //            return true;
    //        }
    //    }

    //    catch (DirectoryNotFoundException e)
    //    {
    //        printout.text = "FUCK YOU";
    //        return false;
    //    }
    //}
}
