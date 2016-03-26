using UnityEngine;
using System.Collections;

public static class centralHub
{


    //treat all numbers like floats
    public static float successes = 0;
    public static float failures = 0;
    public static float playerHealth;
    public static float successRate = 0;
    public static float prevSuccessRate = 0;
    public static float failurePrevention = 0;
    public static float times;
    public static bool playerAlive;
    public static bool goalReached;
    public static float enemiesKilled;
    public static bool updatingChoices = false;
    public static bool updatingGunSpecs = false;
    //public static myList attributeIncrease = new myList();
    public static int totalAttributes = 6;
    public static float [] attributeIncrease = new float[totalAttributes];
    public static float[] clone1;
    public static float[] clone2;
    private static System.Random generator = new System.Random();



    /*
    //my personal linked list
     public class myList{
        int position;
        int size;
        float value;
        myList next;
         public   myList()
        {
            position = -1;
        }

        private void makeANext()
        {
            next = new myList();
        }

        private void setPosition(int p)
        {
            position = p;
        }

        public int getPosition(float v)
        {
            if (position == -1 || v == value)
            {
                return position;
            }
            else
            {
                return next.getPosition(v);
            }
            
        }

        public int length()
        {
            if(position == -1)
            {
                return 0;
            }
            return next.length() + 1;
        }

        public float get(int p)
        {

            if ( p > length() || p < 0)
            {
                //hopefully this doesn't happen
                //this could destroy the universe
                return 0;
            }

            if(p == position)
            {
                return value;
            }
            else
            {
                return next.get(p);
            }           
        }

        public int addToEnd(float v, int lastP)
        {
            //adds to the end of the list
            if(position == -1)
            {
                position = lastP+1;
                value = v;
                makeANext();
                return position;
            }
            else
            {
                return next.addToEnd(v, position);
            }
        }

        public bool set(int p, float v)
        {

            if (p > length() || p < 0)
            {
                //hopefully this doesn't happen
                //this could destroy the universe
                return false;
            }

            if( position == p)
            {
                value = v;
                return true;
            }
            else
            {
                return next.set(p, v);
            }
        }
    }
    //end of the linked list class
    */


        /*
                public static int addToList()
            {
                //returns the position the value will be connected to
                //uses a random increase for first setting
                int positive = generator.Next(0,2);
                if (positive == 0)
                {
                    return attributeIncrease.addToEnd(assignRandomPercentage(true, 0, 20), -1);
                }
                else
                {
                    return attributeIncrease.addToEnd(assignRandomPercentage(false, 0, 20), -1);
                }
            }

            public static float getIncrease(int p)
            {
                return attributeIncrease.get(p);
            }*/

    public static void init()
    {
        for(int i = 0; i < totalAttributes; i++)
        {
            int positive = generator.Next(0, 2);
            if (positive == 0) {
                attributeIncrease[i] = assignRandomPercentage(false,0,20);
            }else
            {
                attributeIncrease[i] = assignRandomPercentage(true, 0, 20);
            }
        }
    }

    public static bool calculate()
    {
        updatingChoices = true;
        updatingGunSpecs = true;
        Debug.Log("upgrading gun");
        prevSuccessRate = successRate;
        successRate = (successes / (successes + failures)) + 0.5F * enemiesKilled;
        clone1 = (float[])attributeIncrease.Clone();
        clone2 = (float[])attributeIncrease.Clone();
        changeAnArray(clone1);
        changeAnArray(clone2);
        updatingChoices = false;

        while (notificationScript.playerIsChoosing)
        {
            //wait for player to choose upgrade
        }

        if(notificationScript.playerChoice == 1)
        {
            attributeIncrease = clone1;
        }else if(notificationScript.playerChoice == 2)
        {
            attributeIncrease = clone2;
        }

        notificationScript.playerIsChoosing = true;
        updatingGunSpecs = false;
        successes = 0;
        failures = 0;
        enemiesKilled = 0;

        return notificationScript.playerChoice != 3;



    }

    //returns a percentage value as a double
    static float assignRandomPercentage(bool positive, int min, int max/*exclusive*/)
    {
        if (positive)
        {
            return generator.Next(min, max) * 0.01F;
        }
        else
        {
            return -generator.Next(min,max) * 0.01F;
        }
    }

    static void changeAnArray(float [] array)
    {
        if (successRate > prevSuccessRate)
        {
            for (int i = 0; i < totalAttributes; i++)
            {
                float copy = array[i];
                float randomNumber = assignRandomPercentage(true, 0, 20);

                if (copy > 0)
                {
                    array[i] = randomNumber;
                }
                else if (copy < 0)
                {
                    array[i] = -randomNumber;
                }
            }
            //the player is getting race
            //go the opposite direction
        }
        else if (successRate > prevSuccessRate)
        {
            for (int i = 0; i < totalAttributes; i++)
            {
                float copy = attributeIncrease[i];
                float randomNumber = assignRandomPercentage(true, 0, 20);



                if (copy > 0)
                {
                    array[i] = -randomNumber;
                }
                else if (copy < 0)
                {
                    array[i] = randomNumber;
                }
                else
                {
                    array[i] = randomNumber;
                }
            }

        }
        //the player is doing everything the exact same
        else
        {

            for (int i = 0; i < totalAttributes; i++)
            {

                float randomNumber = assignRandomPercentage(true, 0, 20);
                int positive = generator.Next(0, 2);

                if (positive == 0)
                {
                    array[i] = -randomNumber;
                }
                else
                {
                    array[i] = randomNumber;
                }


            }
        }

    }


}
