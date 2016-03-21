using UnityEngine;
using System.Collections;

public class characterSuccess : MonoBehaviour {

    public bool alive = true;
    public bool goalReached = false;
    public float health = 100;
    GameObject success = GameObject.Find("Success");
    

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            health -= 10;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            goalReached = true;
        }

        if (health <= 0)
        {
            alive = false;
        }

        if (!alive)
        {

            success.GetComponent<successMeasurer>().incrementFailures();
            //gameObject.GetType().GetField("failures").SetValue(gameObject, (int)gameObject.GetType().GetField("failures").GetValue(gameObject) + 1);
            health = 100;
            alive = true;
        }

        if (goalReached)
        {
            success.GetComponent<successMeasurer>().incrementSuccesses();
            goalReached = false;
        }

	
	}
}
