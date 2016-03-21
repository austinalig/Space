using UnityEngine;
using System.Collections;

public class successTester : MonoBehaviour {


    float whatever;
    float whatever2;
    int position;
    int position2;

	// Use this for initialization
	void Start () {
        whatever = 0;
        whatever2 = 0;
        position = centralHub.addToList();
        position2 = centralHub.addToList();


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            centralHub.calculate();
            whatever += centralHub.getIncrease(position);
            whatever2 += centralHub.getIncrease(position2);
        }

        Debug.Log(whatever+ ", " + whatever2);
        
	}
}
