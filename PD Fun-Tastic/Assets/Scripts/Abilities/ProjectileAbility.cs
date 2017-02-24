using UnityEngine;
using System.Collections;


[CreateAssetMenu (menuName = "Abilities/ProjectileAbilities")]
public class ProjectileAbility : Abilities {
    public Projectile projectile;
   // public LineRenderer line = new LineRenderer();

    public override void Initialise()
    {
        //line.material = new Material(Shader.Find("Unlit/Color"));
        //line.material.color = color;
    }

    public override void TriggerAbility(Vector3 pos, Vector3 direction,int atk)
    {
        
        GameObject proj = Instantiate(projectile.gameObject);
        proj.GetComponent<Projectile>().direction = direction;
        proj.GetComponent<Transform>().position = pos + direction.normalized * 1f;
        proj.transform.Translate(0, 1, 0);
        proj.GetComponent<Projectile>().range = a_range;
        proj.GetComponent<Projectile>().damage = atk * this.a_damage;

        
    }
    public override void DrawAimLine(GameObject player)
    {
        player.GetComponent<AbilityRangeIndicatorRenderer>().DrawProjectileAim(a_range);
    }

    public override int GetType()
    {
        return 1;
    }
    
}
