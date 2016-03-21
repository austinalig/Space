using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class perspectiveSwitcher : MonoBehaviour {

    private GameObject firstPerspective;
    private GameObject thirdPerspective;
    private GameObject firstCamera;
    private GameObject player;
    private bool switcher;

	void Start () {
       //firstPerspective = GameObject.Find("FirstPersonCharacterController");
        firstCamera = GameObject.Find("firstCamera");
        thirdPerspective = GameObject.Find("ThirdPersonCharacter");
        switcher = true;
        player = GameObject.Find("FirstPersonCharacterController");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {

            Debug.Log("Whatever");

            if (switcher)
            {
                //switch to third person

                player.SetActive(false);
                thirdPerspective.SetActive(true);
                firstCamera.SetActive(false);
                switcher = false;
            }
            else
            {
                //switch to first
                gameObject.GetComponent<FirstPersonController>().enabled = true;
                firstCamera.SetActive(true);
                thirdPerspective.SetActive(false);
                switcher = true;
            }

        }

	}
}
