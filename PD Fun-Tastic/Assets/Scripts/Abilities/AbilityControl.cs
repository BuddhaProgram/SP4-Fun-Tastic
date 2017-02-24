using UnityEngine;
using System.Collections;

public class AbilityControl : MonoBehaviour {
    public string axisTriggerName = "";
    //public string joystick_axisTriggerName = "";
    public Abilities ability;
    public GameObject player;
    public AbilityUI ui;
    public Camera cam;

    [HideInInspector]
    public float f_coolDownLeft = 0f;
    [HideInInspector]
    public bool abilityTriggered = false;

    //private bool noOtherAbilityInUse = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (f_coolDownLeft > 0f)
        {
            f_coolDownLeft -= Time.deltaTime;
        }
        if (Input.GetButtonDown(axisTriggerName))
        {
            if (player.GetComponent<AbilityRangeIndicatorRenderer>().skillInUse == false)
            {
                if (ability.a_coolDown > 1f)
                {
                    ability.DrawAimLine(player);
                }
                
            }
        }
        else if (Input.GetButtonUp(axisTriggerName))
        {
            if (f_coolDownLeft <= 0f)
            {
                abilityTriggered = true;
                f_coolDownLeft = ability.a_coolDown * (1.0f - (player.GetComponent<Status>().GetAgi() / 100f));
                if (ability.GetType() == 2)
                {
                    ability.TriggerAbility(cam.GetComponent<camFollowPlayer>().GetMouseOnPlane(), player.transform.forward, player.GetComponent<Status>().GetAtk());
                }
                else {
                    ability.TriggerAbility(player.transform.position, player.transform.forward, player.GetComponent<Status>().GetAtk());
                }

               
                //player.GetComponent<AbilityRangeIndicatorRenderer>().skillInUse = false;
                player.GetComponent<AbilityRangeIndicatorRenderer>().UndrawAim(); 
            }
            
        }
	}
}
