using UnityEngine;
using System.Collections;

public static class sucessMeasurer{

    static int sucesses = 0;
    static int failures = 0;
    static float successRate = 0;
    static float prevSuccessRate = 0;
    static int failurePrevention = 0;
    static string[] attributes;
    static int[] attributeIncrease;
    static int attributeTotal = 7; //Everytime you add an attribute to Shoot.cs, change this. I don't count the rigid body or buttonName

    public static void init()
    {
        sucesses = 0;
        failures = 0;
        successRate = 0;
        prevSuccessRate = 0;
        failurePrevention = 0;
        attributeIncrease = new int[attributeTotal];

        for(int i = 0; i < attributeTotal; i++)
        {
            attributeIncrease[i] = 0;
        }

        attributes[0] = "speed";
        attributes[1] = "fireRate";
        attributes[2] = "nextFire";
        attributes[3] = "xScale";
        attributes[4] = "yScale";
        attributes[5] = "zScale";
        attributes[6] = "destroyAfter";

        
    }
    
}
