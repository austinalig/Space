using UnityEngine;
using System.Collections;

public class playerAttributes: MonoBehaviour{

    public float health = 1;
    public int level = 1;


    playerAttributes() { }

    public void adjustHealth( float newHealth)
    {
        health += newHealth;
        

    }

    void Start()
    {

    }

    void Update()
    {

    }
	
}
