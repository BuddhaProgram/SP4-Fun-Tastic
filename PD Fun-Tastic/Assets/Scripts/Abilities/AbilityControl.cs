using UnityEngine;
using System.Collections;

public class AbilityControl : MonoBehaviour {
    public string axisTriggerName = "";
    //public string joystick_axisTriggerName = "";
    public Abilities ability;
    public GameObject player;
    public AbilityUI ui;

    [HideInInspector]
    public float f_coolDownLeft = 0f;
    [HideInInspector]
    public bool abilityTriggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (f_coolDownLeft > 0f)
        {
            f_coolDownLeft -= Time.deltaTime;
        }
        if (Input.GetButton(axisTriggerName))
        {
            if (f_coolDownLeft <= 0f)
            {
                abilityTriggered = true;
                f_coolDownLeft = ability.a_coolDown * (1.0f - ( player.GetComponent<Status>().GetAgi()/100f));
                ability.TriggerAbility(player.transform.position, player.transform.forward,player.GetComponent<Status>().GetAtk());
            }
            
        }
	}
}
