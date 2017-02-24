using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "Abilities/AOEAbility")]
public class AOEAbility :Abilities {
    public int numOfPulses;
    public float pulseFrequency;

    public AOEAttack aoeEffect;


    public override void Initialise()
    {
    }

    public override void TriggerAbility(Vector3 pos, Vector3 direction, int atk)
    {
        GameObject aoe = Instantiate(aoeEffect.gameObject);
        aoe.transform.Translate(pos.x,pos.y+3,pos.z);
        aoe.GetComponent<AOEAttack>().range = a_range;
        aoe.GetComponent<AOEAttack>().damage = atk * this.a_damage;

        aoe.GetComponent<AOEAttack>().numOfPulses = this.numOfPulses;
        aoe.GetComponent<AOEAttack>().pulseFreq = pulseFrequency;
    }

    public override void DrawAimLine(GameObject player)
    {
        player.GetComponent<AbilityRangeIndicatorRenderer>().DrawAOEAim(a_range);
    }
    public override int GetType()
    {
        return 2;
    }
}
