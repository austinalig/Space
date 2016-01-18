using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour {

    private ArrayList visible;

	// Use this for initialization
	void Start () {
        visible = new ArrayList();
        Debug.Log("Vision Active");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider visibleObject)
    {
        visible.Add(visibleObject.gameObject);

       // if (visibleObject.gameObject.name.Equals("ThirdPersonController"))
      //  {
            Debug.Log("I see you");
      //  }

    }

    void OnTriggerExit(Collider visibleObject)
    {
        visible.Remove(visibleObject.gameObject);

        if (visibleObject.gameObject.name.Equals("ThirdPersonController"))
        {
            Debug.Log("I lost you");
        }

    }
}
