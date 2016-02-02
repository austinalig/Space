using UnityEngine;
using System.Collections;

public static class behaviorAllowance{
    //true = unpaused
    //false = paused
    private static int listLength = 1000;
    private static bool [] pauseList = new bool[listLength] ;
    static void pause(int position)
    {
        //pauses at position
        pauseList[position] = false;
    }

    static void unpause(int position)
    {
        //unpause the list
        pauseList[position] = true;
    }

    static void pauseAll()
    {
        for(int i = 0; i < listLength; i++)
        {
            pauseList[i] = false;
        }
    }

    static void unpauseAll()
    {
        for (int i = 0; i < listLength; i++)
        {
            pauseList[i] = true;
        }
    }

    static void pauseAlldown(int position)
    {
        for (int i = position; i < listLength; i++)
        {
            pauseList[i] = false;
        }
    }

    static void unpauseAlldown(int position)
    {
        for (int i = position; i < listLength; i++)
        {
            pauseList[i] = true;
        }
    }

    static void pauseAllup(int position)
    {
        for (int i = position; i >= 0; i--)
        {
            pauseList[i] = false;
        }
    }

    static void unpauseAllup(int position)
    {
        for (int i = position; i >= 0; i--)
        {
            pauseList[i] = true;
        }
    }


}
