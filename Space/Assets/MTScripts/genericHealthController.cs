using UnityEngine;
using System.Collections;

public class genericHealthController : MonoBehaviour {

    public float healthSubtractor = -0.01F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject healthBar = GameObject.Find("healthBar");
            healthBar.GetComponent<playerAttributes>().adjustHealth(healthSubtractor);

            healthBar.transform.localScale = new Vector3(100* healthBar.GetComponent<playerAttributes>().health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

            healthBar.transform.position = new Vector3(healthBar.transform.position.x+(healthSubtractor*100)/2, healthBar.transform.position.y, healthBar.transform.position.z);

        }


	}
}
