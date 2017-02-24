using UnityEngine;
using System.Collections;

public abstract class Abilities : ScriptableObject {

    public string aName = "My Ability";
    public Sprite asprite;
    public float a_damage = 10f;
    public float a_coolDown = 1f;
    public float a_range = 10f;


  
    public AudioClip audio;
    


    public abstract void Initialise();

    public abstract void TriggerAbility(Vector3 pos, Vector3 direction,int atk);

    public abstract void DrawAimLine(GameObject player);


    public abstract int GetType();
}
