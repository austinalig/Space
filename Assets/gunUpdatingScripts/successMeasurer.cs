using UnityEngine;
using System.Collections;

public class successMeasurer: MonoBehaviour{

    public static int successes = 0;
    public static int failures = 0;
    public static float successRate = 0;
    public static float prevSuccessRate = 0;
    public static int failurePrevention = 0;
    monkeySortGenerator generator = new monkeySortGenerator();
    static string [] attributes;
    static float [] attributeIncrease;
    static int attributeTotal = 7; //Everytime you add an attribute to Shoot.cs, change this. I don't count the rigid body or buttonName
    //replacing Times with these
    public static int successStop = 1;
    public static int failureStop = 10;
    void Awake()
    {
        attributeIncrease = new float [attributeTotal];
        attributes = new string[attributeTotal];

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

        //assign a random increase
        //AI will learn
        for(int i = 0, signOfValue; i < attributeTotal; i++)
        {
            signOfValue = generator.generate(0, 2, 5, 0, 10, 0, 10);
            
            if(signOfValue == 0)
            {
                attributeIncrease[i] = assignRandomPercentage(true,0,51);
            }
            else
            {
                attributeIncrease[i] = assignRandomPercentage(false, 0, 51);
            }
        }     
    }

    void Start()
    {

    }
    void Update()
    {

        //time to update the player's weapon
        if(successes >= successStop || failures >= failureStop)
        {

            Debug.Log("upgrading gun");
            successRate = successes / (successes + failures) + 0.05F * failurePrevention;

            //each task takes a random attribute and changes the range in which it will increase

            //the player is getting better
            //the technique is working
            if(successRate > prevSuccessRate)
            {
                for(int i = generator.generate(0, attributeTotal, 5, 0, 10, 0, 100), prev = 0; i < attributeTotal; prev = i+1, i += generator.generate(0, attributeTotal, 5, 0, 10, 0, 100))
                {

                    //tell the list that certain elements were skipped
                    while(prev < i)
                    {
                        attributeIncrease[prev] = 0;
                        prev++;
                    }

                    //continue increasing or decreasing
                    if(attributeIncrease[i] > 0)
                    {
                        attributeIncrease[i] = assignRandomPercentage(true, 1, 51);
                    }else if(attributeIncrease[i] < 0)
                    {
                        attributeIncrease[i] = assignRandomPercentage(false, 1, 51);
                    }
                }

            }
            //player is still playing the same
            //technique isn't working nor failing
            else if(successRate == prevSuccessRate)
            {
                for(int i = generator.generate(0,attributeTotal,5,0,10,0,100), prev = 0; i < attributeTotal; prev = i+1, i += generator.generate(1, attributeTotal, 5, 0, 10, 0, 100))
                {

                    //tell the list that certain elements were skipped
                    while (prev < i)
                    {
                        attributeIncrease[prev] = 0;
                        prev++;
                    }
                    int sign = generator.generate(0,2,5,0,10,0,10);

                    if(sign == 0)
                    {
                        attributeIncrease[i] = assignRandomPercentage(true, 1, 51);
                    }
                    else
                    {
                        attributeIncrease[i] = assignRandomPercentage(false, 1, 51);
                    }

                }

            //player is doing worse than before
            //technique is failing
            }else
            {
                for (int i = generator.generate(0, attributeTotal, 5, 0, 10, 0, 100), prev = 0; i < attributeTotal; prev = i + 1, i += generator.generate(0, attributeTotal, 5, 0, 10, 0, 100))
                {

                    //tell the list that certain elements were skipped
                    while (prev < i)
                    {
                        attributeIncrease[prev] = 0;
                        prev++;
                    }

                    //switch up the increasing or decreasing
                    if (attributeIncrease[i] > 0)
                    {
                        attributeIncrease[i] = assignRandomPercentage(false, 1, 51);
                    }
                    else if (attributeIncrease[i] < 0)
                    {
                        attributeIncrease[i] = assignRandomPercentage(true, 1, 51);
                    }
                }
            }

            //incorporate changes
            for(int i = 0; i < attributeTotal; i++)
            { GameObject theMuzzle = GameObject.Find("Muzzle");
                //If this works right, it increases/decreases value in the class
                theMuzzle.GetType().GetField(attributes[i]).SetValue(theMuzzle,((float)theMuzzle.GetType().GetField(attributes[i]).GetValue(theMuzzle)) + ((float)theMuzzle.GetType().GetField(attributes[i]).GetValue(theMuzzle)) * attributeIncrease[i]);
            }

            prevSuccessRate = successRate;
            successes = 0;
            failures = 0;

        }
    }

    public void incrementFailures()
    {
        failures++;
    }

    public void incrementSuccesses()
    {
        successes++;
    }


    //returns a percentage value as a double
    float assignRandomPercentage(bool positive, int min, int max/*exclusive*/)
    {
        if (positive)
        {
            return generator.generate(min, max, 5, 0, 10, 0, 100) * 0.01F;
        }
        else
        {
            return -generator.generate(min, max, 5, 0, 10, 0, 100) * 0.01F;
        }
    }

    
}
