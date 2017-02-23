using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
    public int atk = 1;
    public int agi = 1;
    public int vit = 1;


    [HideInInspector]
    public int atk_eq;
    [HideInInspector]
    public int agi_eq;
    [HideInInspector]
    public int vit_eq;


    public int GetAtk()
    {
        return atk + atk_eq;
    }

    public int GetAgi()
    {
        return agi + agi_eq;
    }
    public int GetVit()
    {
        return vit + vit_eq;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
