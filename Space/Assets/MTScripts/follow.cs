using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public static class follow{

	// Use this for initialization
	
        //this assumes 'theobject' has 'AICharacterControl' applied to it
    public static void setPath(GameObject theObject, GameObject theTarget)
    {
        theObject.GetComponent<AICharacterControl>().target = theTarget.transform;
    }

}
