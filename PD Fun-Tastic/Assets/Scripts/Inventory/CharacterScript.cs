using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<CharacterSlot>().index = i;
        }
    }

}
