using UnityEngine;
using System.Collections;

public class temporaryEnemyScriptForGunUpgrade : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<damageDealer>().health <= 0)
        {
            centralHub.successes++;
            gameObject.GetComponent<damageDealer>().health = 100;
        }
	}
}
