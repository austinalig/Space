using System;

public class monkeySort  {

    Random rnd;
    public monkeySort()
    {
        rnd = new Random();

    }

    public int generate(int min, int max, int listMin, int listMax, int listSize, int minTurns, int maxTurns)
    {
        int result = min;

        int [] list = new int[listSize];

        for(int i = 0; i < listSize; i++)
        {
            list[i] = rnd.Next(listMin, listMax);
        }

        int first;
        int second;

        for (int i = 0; (i < minTurns || i < maxTurns) && listSorted(list); i++)
        {
            first = rnd.Next(0,listSize);
            second = rnd.Next(0, listSize);
            switchTwo(first, second, list);
            result = i % (max - min) + min;


            if (i == maxTurns - 1 && !listSorted(list))
            {
                result = rnd.Next(min,max);
            }
        }


        return result;

    }

    private void switchTwo(int first, int second, int [] list)
    {

        int hold = list[first];
        list[first] = list[second];
        list[second] = hold;

    }

    private bool listSorted(int [] list )
    {
        for(int i = 0; i < list.Length; i++)
        {
            for(int j = i + 1; j < list.Length; j++)
            {
                if(list[j] < list[i])
                {
                    return false;
                }
            }

        }
        return true;
    }
    
}
