using UnityEngine;
using System.Collections;

public class HotbarSlotScript : MonoBehaviour {

	void Start ()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<Hotbar>().index = i;
        }
	}
}
