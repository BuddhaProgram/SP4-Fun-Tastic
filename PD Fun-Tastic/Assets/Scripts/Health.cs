using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum ELEMENTS
{
    FIRE=0,
    WATER,
    LIGHTNING,
    NULL
};


public class Health : MonoBehaviour {

   
    public float maxHealth = 100f;
    public float initialHealth = 100f;
    public float health;
	private GameObject healthBar;

    public ELEMENTS element = ELEMENTS.NULL;

	// Use this for initialization
	void Start () {
        health = initialHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

		healthBar = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//healthBar.GetComponent<Transform> ().SetParent (gameObject.GetComponent<Transform> ());
		healthBar.GetComponent<MeshRenderer> ().material.color = Color.red;
		healthBar.GetComponent<BoxCollider> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		float howMuchToMove = ((maxHealth - health) / maxHealth) * 0.5f;
		healthBar.transform.position = new Vector3(-howMuchToMove, 0.0f, 1.2f) + gameObject.transform.position;
		healthBar.transform.localScale = new Vector3 (health / maxHealth, 0.1f, 0.1f);
	}

    public void ReceiveDamage(float damage,ELEMENTS atkelement = ELEMENTS.NULL)
    {
        // Check vit stats
        damage = damage / (float)this.GetComponent<Status>().GetVit();

        // check for elemental weakness
        if (this.element == ELEMENTS.FIRE)
        {
            if (atkelement == ELEMENTS.WATER)
            {
                damage *= 1.3f;
            }
            else if (atkelement == ELEMENTS.LIGHTNING)
            {
                damage *= 0.7f;
            }
        }

        else if (this.element == ELEMENTS.WATER)
        {
            if (atkelement == ELEMENTS.LIGHTNING)
            {
                damage *= 1.3f;
            }
            else if (atkelement == ELEMENTS.FIRE)
            {
                damage *= 0.7f;
            }
        }
        else if (this.element == ELEMENTS.LIGHTNING)
        {
            if (atkelement == ELEMENTS.FIRE)
            {
                damage *= 1.3f;
            }
            else if (atkelement == ELEMENTS.WATER)
            {
                damage *= 0.7f;
            }
        }
        
        this.health -= damage;

        GameObject obj = Instantiate(Resources.Load<GameObject>("DamageText"));
        obj.transform.position = this.transform.position + new Vector3(1, 0, 0);
        obj.GetComponent<TextMesh>().text = damage.ToString();

        if (health < 0f)
        {
            health = 0f;
        }
    }

    public void Heal(float heal)
    {
        this.health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
