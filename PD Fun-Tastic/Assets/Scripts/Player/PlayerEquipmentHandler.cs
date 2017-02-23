using UnityEngine;
using System.Collections;

public class PlayerEquipmentHandler : MonoBehaviour
{

    public CharacterSlot weapon;
    public CharacterSlot head;
    public CharacterSlot body;
    public CharacterSlot legs;

    public AbilityControl basic;
    public AbilityControl skill1;
    public AbilityControl skill2;
    public AbilityControl skill3;

    public AbilityUI basicUI;
    public AbilityUI skill1_UI;
    public AbilityUI skill2_UI;
    public AbilityUI skill3_UI;

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


        if (weapon.item.itemType != Item.ItemType.None)
        {
            s.atk_eq += weapon.item.atk;
            s.vit_eq += weapon.item.vit;
            s.agi_eq += weapon.item.agi;
            basic.ability = weapon.item.ability;
            //basic.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }
        else
        {
            basic.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }


        if (head.item.itemType != Item.ItemType.None)
        {

            s.atk_eq += head.item.atk;
            s.vit_eq += head.item.vit;
            s.agi_eq += head.item.agi;
            skill1.ability = head.item.ability;
            //skill1.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }
        else
        {
            skill1.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (body.item.itemType != Item.ItemType.None)
        {
            //skill2.ability = body.item.ability;
            s.atk_eq += body.item.atk;
            s.vit_eq += body.item.vit;
            s.agi_eq += body.item.agi;
        }
        else
        {
            //skill2.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (legs.item.itemType != Item.ItemType.None)
        {
            //skill3.ability = legs.item.ability;
            s.atk_eq += legs.item.atk;
            s.vit_eq += legs.item.vit;
            s.agi_eq += legs.item.agi;
        }
        else
        {
            //skill3.ability = AbilityDataBase.GetInstance().GetAbility("Basic Ability");
        }

        if (lastBasic != basic.ability.aName)
        {
            basicUI.Initialize();
        }

        if (lastSkill1 != skill1.ability.aName)
        {
            skill1_UI.Initialize();
        }

        //if (lastSkill2 != skill2.ability.aName)
        //{
        //    skill2_UI.Initialize();
        //}
        //if (lastSkill3 != skill3.ability.aName)
        //{
        //    skill3_UI.Initialize();
        //}




    }
}
