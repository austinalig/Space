using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class perspectiveSwitcher : MonoBehaviour {

    private GameObject firstPerspective;
    private GameObject thirdPerspective;
    private GameObject firstCamera;
    private bool switcher;

	void Start () {
       //firstPerspective = GameObject.Find("FirstPersonCharacterController");
        firstCamera = GameObject.Find("firstCamera");
        thirdPerspective = GameObject.Find("ThirdPersonCharacter");
        switcher = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))
        {

            Debug.Log("Whatever");

            if (switcher)
            {
                //switch to third person
                gameObject.GetComponent<FirstPersonController>().enabled = false;
                firstCamera.SetActive(false);
                thirdPerspective.SetActive(true);
                switcher = false;
            }
            else
            {
                //switch to first
                gameObject.GetComponent<FirstPersonController>().enabled = true;
                firstCamera.SetActive(false);
                thirdPerspective.SetActive(false);
                switcher = true;
            }

        }

	}
}
