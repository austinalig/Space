using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class retreatScript : MonoBehaviour {

    // Use this for initialization
    private GameObject AIObject;
    private Transform locatedTarget;
    private bool on;
    private monkeySortGenerator random;
    void Start () {
        random = new monkeySortGenerator();
        AIObject = GameObject.Find("AIThirdPersonController 4");
        locatedTarget = GameObject.Find("GameObject").transform; ;
        on = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("space pressed");
            on = !on;
            
            if (on)
            {
                locatedTarget = GameObject.Find("GameObject").transform;
                float newX;
                float newY;
                float newZ = locatedTarget.position.z;//leaving z the same for now
                do {
                    newX = random.generate(-2000, 2000, 7, 0, 20, 0, 4000);
                    newY = random.generate(-2000, 2000, 7, 0, 20, 0, 4000);
                } while (newX == locatedTarget.position.x
                      && newY == locatedTarget.position.y);
                Debug.Log("x" + newX + ": y" + newY);
                Transform nothing = locatedTarget;
                nothing.position = new Vector3(newX, newY, newZ);

                AIObject.GetComponent<AICharacterControl>().target = nothing;
            }else
            {
                AIObject.GetComponent<AICharacterControl>().target = GameObject.Find("GameObject").transform;
            }
        }

    }
}
