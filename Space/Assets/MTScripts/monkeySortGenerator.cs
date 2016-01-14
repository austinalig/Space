using System.Collections;
using System;

//code is used to return a random number given certain parameters
public class monkeySortGenerator {
    monkeySortGenerator() { }


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
        list[second] = list[first];
    }

    //full algorithm
    public int generate(int min, int max, int listSize, int listMin, int listMax, int minTurns, int maxTurns)
    {
        int [] list = new int[listSize];
        int result = 0;
        Random generator = new Random();
        for(int i = 0; i < listSize; i++)
        {
            list[i] = generator.Next(listMin, listMax);
        }

        for(int i = 0; i < minTurns || i < maxTurns; i++)
        {
            int firstPosition = generator.Next(0, listSize);
            int secondPosition = generator.Next(0, listSize);
            switchTwo(list, firstPosition, secondPosition);

            if(i >= minTurns)
            {
                i = maxTurns;
            }
            result = i;
        }

        result = result % (max - min) + min;

        return result;

    }



}
