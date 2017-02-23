using UnityEngine;
using System.Collections;

public class HotBarSlotScript2 : MonoBehaviour {

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<HotbarSecondary>().index = i;
        }
    }
}
