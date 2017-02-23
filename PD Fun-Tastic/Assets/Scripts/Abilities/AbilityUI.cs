using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour {

    public Image darkMask;
    public Text coolDownTextDisplay;
    public AbilityControl abilityControl;

    private AudioSource audio;

    private bool abilityReady = false;
    private float cooldownDuration = 0f;

	// Use this for initialization
	void Start () {
        audio = gameObject.AddComponent<AudioSource>();
        Initialize();
        AbilityReady();
	}

    public void Initialize()
    {
        darkMask.sprite = abilityControl.ability.asprite;
        GetComponent<Image>().sprite = abilityControl.ability.asprite;
        audio.clip = abilityControl.ability.audio;
        cooldownDuration = abilityControl.ability.a_coolDown;
        
    }

    void AbilityReady()
    {
        darkMask.enabled = false;
        coolDownTextDisplay.enabled = false;
        abilityReady = true;
    }

    void AbilityTriggered()
    {
        //audio.Play();
        abilityControl.abilityTriggered = false;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;
        abilityReady = false;
        audio.Play();
    }

	// Update is called once per frame
	void Update () {
        
        if (abilityReady == false)
        {
            float roundedCd = Mathf.Round(abilityControl.f_coolDownLeft);
            coolDownTextDisplay.text = roundedCd.ToString();
            darkMask.fillAmount = (abilityControl.f_coolDownLeft / cooldownDuration);
            if (abilityControl.f_coolDownLeft <= 0f)
            {
                AbilityReady();
            }
        }
        else
        {
            if (abilityControl.abilityTriggered)
            {
                AbilityTriggered();
            }
        }
	}
}
