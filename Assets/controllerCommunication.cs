using UnityEngine;
using System.Collections;

public class controllerCommunication : MonoBehaviour {

    private bool perspective = false;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))
        {
            if (perspective)
            {
                
                perspective = false;
            }
            else
            {
                perspective = true;
            }

        }
	
	}


}
