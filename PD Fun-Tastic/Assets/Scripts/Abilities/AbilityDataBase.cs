using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityDataBase {

    private static AbilityDataBase instance = null;

    private Dictionary<string, Abilities> abilityData = new Dictionary<string,Abilities>();

    public static AbilityDataBase GetInstance()
    {
        if (instance == null)
        {
            instance = new AbilityDataBase();
            instance.Init();
        }
        return instance;
    }

    void Init()
    {
        string filepath = "Scriptable Objects/Abilities/";

        Abilities ability;
        ability = Resources.Load<Abilities>(filepath + "Fire Ball");
        abilityData.Add("Fire Ball", ability);

        Abilities ability2;
        ability2 = Resources.Load<Abilities>(filepath + "Basic Ability");
        abilityData.Add("Basic Ability", ability2);

        Abilities ability3;
        ability3 = Resources.Load<Abilities>(filepath + "Lightning Ball");
        abilityData.Add("Lightning Ball", ability3);
        

    }


    public Abilities GetAbility(string abilityName)
    {
        Abilities temp;
        this.abilityData.TryGetValue(abilityName, out temp);
        return temp;
    }

   

}
