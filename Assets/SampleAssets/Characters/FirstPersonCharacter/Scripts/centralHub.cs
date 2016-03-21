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
    private static monkeySortGenerator generator = new monkeySortGenerator();
    public static myList attributeIncrease = new myList();
    static int attributeTotal;




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

        


        public static int addToList()
    {
        //returns the position the value will be connected to
        //uses a random increase for first setting
        int positive = generator.generate(0, 2, 5, 0, 10, 0, 100);
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
    }

    public static void calculate()
    {
        Debug.Log("upgrading gun");
        prevSuccessRate = successRate;
        successRate = (successes / (successes + failures)) + 0.5F * enemiesKilled;

        //the player is getting better
        //the technique is working
        if (successRate > prevSuccessRate)
        {
            for(int i = 0; i < attributeIncrease.length(); i++)
            {
                float copy = attributeIncrease.get(i);
                float randomNumber =  assignRandomPercentage(true, 0, 20);

                if (copy > 0)
                {
                    attributeIncrease.set(i, randomNumber);
                }else if(copy < 0)
                {
                    attributeIncrease.set(i, -randomNumber);
                }
            }
            //the player is getting race
            //go the opposite direction
        }else if(successRate > prevSuccessRate)
        {
            for (int i = 0; i < attributeIncrease.length(); i++)
            {
                float copy = attributeIncrease.get(i);
                float randomNumber = assignRandomPercentage(true, 0, 20);

                

                if (copy > 0)
                {
                    attributeIncrease.set(i, -randomNumber);
                }
                else if (copy < 0)
                {
                    attributeIncrease.set(i, randomNumber);
                }
                else
                {
                    attributeIncrease.set(i, randomNumber);
                }
            }

        }
        //the player is doing everything the exact same
        else
        {

            for (int i = 0; i < attributeIncrease.length(); i++)
            {
                
                float randomNumber = assignRandomPercentage(true, 0, 20);
                int positive = generator.generate(0, 2, 5, 0, 10, 0, 100);

                if (positive == 0)
                {
                    attributeIncrease.set(i, -randomNumber);
                }
                else
                {
                    attributeIncrease.set(i, randomNumber);
                }
            }
        }

        }

    //returns a percentage value as a double
    static float assignRandomPercentage(bool positive, int min, int max/*exclusive*/)
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
