using UnityEngine;
using System.Collections;

public class PlayerEquipmentHandler : MonoBehaviour
{

    public EquipmentSlot weapon;
    public EquipmentSlot head;
    public EquipmentSlot body;
    public EquipmentSlot legs;

    public AbilityControl basic;
    public AbilityControl skill1;
    public AbilityControl skill2;
    public AbilityControl skill3;

    public AbilityUI basicUI;
    public AbilityUI skill1_UI;
    public AbilityUI skill2_UI;
    public AbilityUI skill3_UI;

 
    public AbilityUI mobile_skill1_UI;
    public AbilityUI mobile_skill2_UI;
    public AbilityUI mobile_skill3_UI;

    private string lastBasic;
    private string lastSkill1;
    private string lastSkill2;
    private string lastSkill3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        lastBasic = basic.ability.aName;
        lastSkill1 = skill1.ability.aName;
        //lastSkill2 = skill2.ability.aName;
        //lastSkill3 = skill3.ability.aName;

        Status s = gameObject.GetComponent<Status>();

        s.atk_eq = 0;
        s.vit_eq = 0;
        s.agi_eq = 0;


        if (weapon.storedItem != null)
        {
            s.atk_eq += weapon.storedItem.atk;
            s.vit_eq += weapon.storedItem.vit;
            s.agi_eq += weapon.storedItem.agi;
            basic.ability = weapon.storedItem.ability;
           // basic.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }
        else
        {
            basic.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }


        if (head.storedItem != null)
        {

            s.atk_eq += head.storedItem.atk;
            s.vit_eq += head.storedItem.vit;
            s.agi_eq += head.storedItem.agi;
            skill1.ability = head.storedItem.ability;
            //skill1.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }
        else
        {
            skill1.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (body.storedItem != null)
        {
            skill2.ability = body.storedItem.ability;
            s.atk_eq += body.storedItem.atk;
            s.vit_eq += body.storedItem.vit;
            s.agi_eq += body.storedItem.agi;
        }
        else
        {
            skill2.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (legs.storedItem != null)
        {
            skill3.ability = legs.storedItem.ability;
            s.atk_eq += legs.storedItem.atk;
            s.vit_eq += legs.storedItem.vit;
            s.agi_eq += legs.storedItem.agi;
        }
        else
        {
            skill3.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (lastBasic != basic.ability.aName)
        {
            basicUI.Initialize();
        }

        if (lastSkill1 != skill1.ability.aName)
        {
            skill1_UI.Initialize();
            mobile_skill1_UI.Initialize();
        }

        if (lastSkill2 != skill2.ability.aName)
        {
            skill2_UI.Initialize();
            mobile_skill2_UI.Initialize();
        }
        if (lastSkill3 != skill3.ability.aName)
        {
            skill3_UI.Initialize();
            mobile_skill3_UI.Initialize();
        }




    }
}
