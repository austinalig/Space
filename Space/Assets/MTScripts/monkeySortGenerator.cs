using System.Collections;
using System;

//code is used to return a random number given certain parameters
public class monkeySortGenerator {
    public monkeySortGenerator() { }


    //checks the list
    private bool checkSorted(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i; j < list.Length; j++)
            {
                if (list[i] > list[j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    //switch two positions in the list
    private void switchTwo(int[] list, int first, int second){
        int hold = list[first];
        list[first] = list[second];
        list[second] = hold;
    }

    //full algorithm
    //max is exclusive
    public int generate(int min, int max, int listSize, int listMin, int listMax, int minTurns, int maxTurns)
    {
        int [] list = new int[listSize];
        int result = 0;
        Random generator = new Random();
        for(int i = 0; i < listSize; i++)
        {
            list[i] = generator.Next(listMin, listMax);
        }

        for(int i = 0; i < minTurns || i <= maxTurns; i++)
        {
            int firstPosition = generator.Next(0, listSize);
            int secondPosition = generator.Next(0, listSize);
            switchTwo(list, firstPosition, secondPosition);

            //if the algorithm is taking too long, resort to fallback
            if (i == maxTurns)
            {
                result = generator.Next(minTurns, maxTurns);
            }

            if (i >= minTurns && checkSorted(list))
            {
                result = i;
                i = maxTurns;
            }

        }

        result = result % (max - min) + min;

        return result;

    }



}
