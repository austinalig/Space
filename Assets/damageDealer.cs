using UnityEngine;
using System.Collections;

public class damageDealer : MonoBehaviour {
    /*Deal damage to or take damage from...
    *0 both
    *1 enemy only
    *2 player only
    *3 none 
    */
    public int damageType = 0;
    public int damageGiving = 0;
    public int startingHealth = 100;
    public int health;

	// Use this for initialization
	void Start () {
        health = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if(health <= 0)
        {
            if(damageType == 1)
            {
                centralHub.enemiesKilled++;
            }else if(damageType == 2)
            {
                centralHub.failures++;
            }

            health = startingHealth;
        }

	}

    void OnCollisionEnter(Collision col)
    {
        int otherDamageType = col.gameObject.GetComponent<damageDealer>().damageType;
        if (otherDamageType != 0 && otherDamageType != damageType) {
            health -= (col.gameObject.GetComponent<damageDealer>().damageGiving);
            }
        Debug.Log(health);

    }

}
