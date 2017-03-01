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

    public bool mobile;
    public bool pressed = false;
    public bool released = false;

    //private bool noOtherAbilityInUse = true;
	// Use this for initialization
	void Start () {
        mobile = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (f_coolDownLeft > 0f)
        {
            f_coolDownLeft -= Time.deltaTime;
        }
        if (mobile == false)
        {
            Debug.Log("mobile is false");
            if (Input.GetButtonDown(axisTriggerName))
            {
                Pressed();
            }
            else if (Input.GetButtonUp(axisTriggerName))
            {
                Released();
            }
        }
        else {
            Debug.Log("mobile is true");
            if (pressed == true)
            {
                Pressed();
            }
            if (released == true)
            {
                Released();
            }

        }
        
	}

    public void Pressed()
    {
        if (player.GetComponent<AbilityRangeIndicatorRenderer>().skillInUse == false)
        {
            if (ability.a_coolDown > 1f && f_coolDownLeft<=0f)
            {
                ability.DrawAimLine(player);
            }

        }
    }

    public void Released()
    {
        pressed = false;
        released = false;
        if (f_coolDownLeft <= 0f)
        {
            abilityTriggered = true;
            f_coolDownLeft = ability.a_coolDown * (1.0f - (player.GetComponent<Status>().GetAgi() / 100f));
            if (ability.GetType() == 2)
            {
                ability.TriggerAbility(cam.GetComponent<camFollowPlayer>().GetMouseOnPlane(), player.transform.forward, player.GetComponent<Status>().GetAtk());
            }
            else
            {
                ability.TriggerAbility(player.transform.position, player.transform.forward, player.GetComponent<Status>().GetAtk());
            }


            //player.GetComponent<AbilityRangeIndicatorRenderer>().skillInUse = false;
           
        }
        player.GetComponent<AbilityRangeIndicatorRenderer>().UndrawAim();
            
    }
}
