using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class levelGenerator : MonoBehaviour
{

    public GameObject level;

    private GameObject [] levelList;

    private int [] norths;
    private int[] easts;
    private int[] souths;
    private int[] wests;

    private int[] levelDesign;



    public int size = 1;

    private monkeySortGenerator random;

    public int collums = 6;
    public int rows = 5;

    private int totalTypesOfMaps = 15;

    private int totalLevels;
    public Sprite one;
    public Sprite end;

    private const int north = 0;
    private const int east = 1;
    private const int south = 2;
    private const int west = 3;



    void Start()
    {

        totalLevels = collums * rows;
        norths = new int[8];
        easts = new int[8];
        souths = new int[8];
        wests = new int[8];
        levelDesign = new int[totalLevels];

        norths[0] = 1;
        norths[1] = 5;
        norths[2] = 6;
        norths[3] = 7;
        norths[4] = 11;
        norths[5] = 12;
        norths[6] = 13;
        norths[7] = 15;

        easts[0] = 2;
        easts[1] = 5;
        easts[2] = 8;
        easts[3] = 9;
        easts[4] = 11;
        easts[5] = 12;
        easts[6] = 14;
        easts[7] = 15;


        souths[0] = 3;
        souths[1] = 6;
        souths[2] = 8;
        souths[3] = 10;
        souths[4] = 11;
        souths[5] = 13;
        souths[6] = 14;
        souths[7] = 15;

        wests[0] = 4;
        wests[1] = 7;
        wests[2] = 9;
        wests[3] = 10;
        wests[4] = 12;
        wests[5] = 13;
        wests[6] = 14;
        wests[7] = 15;

        for (int i = 0; i < levelDesign.Length; i++) { 
        levelDesign[i] = 0;
    }
         random = new monkeySortGenerator();
        levelList = new GameObject[totalLevels];


        Debug.Log(assignLevels(north,random.generate(0,levelList.Length,10,0,10,10,100)));

        /*
        int zIncrease = -1;
        bool startSpace = false;
        bool endSpace = false;

        for (int i = 0; i < totalLevels; i++)
        {

            int someNum;
            if(i % 6 == 0)
            {
                zIncrease++;
            }
            float xPos = size *(i % 6);
            float zPos = size * zIncrease;

            Vector3 copy = level.transform.position;

            copy.x = xPos;
            copy.z = zPos;


            levelList[i] = (GameObject)GameObject.Instantiate(level,copy,level.transform.rotation);
            levelList[i].name = level.name + i;

            if (!startSpace)
            {
                someNum = random.generate(0, 10, 10, 0, 10, 5, 10);
                Debug.Log(i + ", " + someNum);
                if (someNum % 5 == 0)
                {
                    
                    levelList[i].name = level.name + "start";
                    GameObject player = GameObject.Find("ThirdPersonController");
                    player.transform.position = new Vector3(xPos, player.transform.position.y, zPos);
                    levelList[i].GetComponent<SpriteRenderer>().sprite = one;
                    startSpace = true;
                }
            }

            if (!endSpace && !levelList[i].name.Contains("start"))
            {
                someNum = random.generate(0, 10, 10, 0, 10, 0, 10);
                Debug.Log(i + ", " + someNum);
                if (someNum % 5 == 0)
                {
                    levelList[i].name = level.name + "end";
                    levelList[i].GetComponent<SpriteRenderer>().sprite = end;
                    endSpace = true;
                }

            }


            if(i == totalLevels - 2 && !startSpace)
            {
                levelList[i].name = level.name + "start";
                GameObject player = GameObject.Find("ThirdPersonController");
                player.transform.position = new Vector3(xPos, player.transform.position.y, zPos);
                levelList[i].GetComponent<SpriteRenderer>().sprite = one;
                startSpace = true;
            }else if(i == totalLevels - 1 && !endSpace)
            {
                levelList[i].name = level.name + "end";
                levelList[i].GetComponent<SpriteRenderer>().sprite = end;
                endSpace = true;
            }
        }*/


    }

    //0 north
    //1 east
    //2 south
    //3 west
    //recurse to build map
    bool assignLevels(int direction, int position)
    {

        int nextPosition;
        bool[] tried = new bool[8];

        for (int i = 0; i < 8; i++)
        {
           tried[i] = false;
        }

        //four directions to check
        bool northOpen = true;
        bool eastOpen = true;
        bool southOpen = true;
        bool westOpen = true;

        //what type of map is this
        //generate a new one
        while (!triedAll(tried)) {
            Debug.Log("Entered");         
            int thisSpaceType;
            int looped = 0;

            //found an error that means it's a waste of time to keep trying this space type
            bool abort = false;

            //this code repeats four times, once for all directions
            if (position == north) {

                //create a possible map choice
                /*conditions (excluding abort):
                1. type is inside the proper direction
                2. type hasn't been tried yet
                3. we haven't run out of positions to try
                4. type didn't hit the end of the list (this is basically a fallback for 3)
                */
                do {

                    //don't take too long
                    if (looped == 3)
                    {
                        thisSpaceType = findNextFalse(0,tried);
                    }
                    else {
                        thisSpaceType = random.generate(1, 16, 10, 0, 10, 10, 100);
                        looped++;
                    }
                } while (!abort && !insideOf(thisSpaceType, souths) && !tried[findPosition(thisSpaceType,souths)] && !triedAll(tried) && thisSpaceType != -1);

                //reset so next loop stays randomized
                looped = 0;

                //we're trying this space type now
                tried[findPosition(thisSpaceType, souths)] = true;

                //add this to the official list for recursion method recognition
                //will reset outside of loop (if exits loop, there is no solution)
                levelDesign[position] = thisSpaceType;

                //we're comming from the south, so falsify it
                southOpen = false;

                //check what directions we're allowed to go
                //don't have to check south because it's closed
                //If we're on the edge and ar still traveling, abort the process
                if (!insideOf(thisSpaceType,norths))
                {
                    northOpen = false;
                }else if (position >= (rows * (collums - 1)))
                {
                    //we're on the edge but can still travel this way
                    //this should not be, abort
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, easts))
                {
                    eastOpen = false;
                }
                else if (position % rows == 0)
                {
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, wests))
                {
                    westOpen = false;
                } else if (position % rows == 1)
                {
                    
                    abort = true;
                }

                
                if (!abort) {
                    //start recurssion
                    if (northOpen)
                    {
                        //we're going up
                        nextPosition = position + collums;

                        //no one has touched this position yet
                        if (levelDesign[nextPosition] == 0)
                        {
                            northOpen = !assignLevels(north, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], souths))
                        {
                            //if this position has been filled, check if it meets the properties
                            //if it does, fine. If not, keep north open because we have to go back
                            northOpen = false;
                        }
                        else
                        {
                            //neither conditions are true, we can't go north here
                            abort = true;
                        }
                    }
                    if (!abort && eastOpen)
                    {
                        nextPosition = position + 1;
                       
                        if (levelDesign[nextPosition] == 0)
                        {
                            eastOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], wests))
                        {
                            eastOpen = false;

                        }else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && westOpen)
                    {
                        nextPosition = position - 1;

                        if (levelDesign[nextPosition] == 0)
                        {
                            westOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], easts))
                        {
                            eastOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }
                }

                //repeat this section of code for the other three directions

            }
            else if (position == east)
            {

                do
                {
                    if (looped == 3)
                    {
                        thisSpaceType = findNextFalse(0, tried);
                    }
                    else {
                        thisSpaceType = random.generate(1, 16, 10, 0, 10, 10, 100);
                        looped++;
                    }
                } while (!abort && !insideOf(thisSpaceType, wests) && !tried[findPosition(thisSpaceType, wests)] && !triedAll(tried) && thisSpaceType != -1);
                looped = 0;
                tried[findPosition(thisSpaceType, wests)] = true;

                levelDesign[position] = thisSpaceType;

                westOpen = false;

                if (!insideOf(thisSpaceType, norths))
                {
                    northOpen = false;
                }
                else if (position >= (rows * (collums - 1)))
                {
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, easts))
                {
                    eastOpen = false;
                }
                else if (position % rows == 0)
                {
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, souths))
                {
                    southOpen = false;
                }
                else if (position < collums)
                {

                    abort = true;
                }


                if (!abort)
                {
                    if (northOpen)
                    {                       
                        nextPosition = position + collums;                      
                        if (levelDesign[nextPosition] == 0)
                        {
                            northOpen = !assignLevels(north, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], souths))
                        {                       
                            northOpen = false;
                        }
                        else
                        {
                            abort = true;
                        }
                    }
                    if (!abort && eastOpen)
                    {
                        nextPosition = position + 1;

                        if (levelDesign[nextPosition] == 0)
                        {
                            eastOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], wests))
                        {
                            eastOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && southOpen)
                    {
                        nextPosition = position - collums;

                        if (levelDesign[nextPosition] == 0)
                        {
                            southOpen = !assignLevels(south, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], norths))
                        {
                            southOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }
                }

            }
            else if (position == south)
            {
                do
                {
                    if (looped == 3)
                    {
                        thisSpaceType = findNextFalse(0, tried);
                    }
                    else {
                        thisSpaceType = random.generate(1, 16, 10, 0, 10, 10, 100);
                        looped++;
                    }
                } while (!abort && !insideOf(thisSpaceType, norths) && !tried[findPosition(thisSpaceType, norths)] && !triedAll(tried) && thisSpaceType != -1);
                looped = 0;
                tried[findPosition(thisSpaceType, norths)] = true;

                levelDesign[position] = thisSpaceType;

                northOpen = false;



                if (!abort && !insideOf(thisSpaceType, easts))
                {
                    eastOpen = false;
                }
                else if (position % rows == 0)
                {
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, souths))
                {
                    southOpen = false;
                }
                else if (position < collums)
                {

                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, wests))
                {
                    westOpen = false;
                }
                else if (position % rows == 1)
                {

                    abort = true;
                }


                if (!abort)
                {
                    
                    if (!abort && eastOpen)
                    {
                        nextPosition = position + 1;

                        if (levelDesign[nextPosition] == 0)
                        {
                            eastOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], wests))
                        {
                            eastOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && southOpen)
                    {
                        nextPosition = position - collums;

                        if (levelDesign[nextPosition] == 0)
                        {
                            southOpen = !assignLevels(south, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], norths))
                        {
                            southOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && westOpen)
                    {
                        nextPosition = position - 1;

                        if (levelDesign[nextPosition] == 0)
                        {
                            westOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], easts))
                        {
                            eastOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }
                }
            }
            //this is west
            else
            {

                do
                {
                    if (looped == 3)
                    {
                        thisSpaceType = findNextFalse(0, tried);
                    }
                    else {
                        thisSpaceType = random.generate(1, 16, 10, 0, 10, 10, 100);
                        looped++;
                    }
                } while (!abort && thisSpaceType != -1 && !insideOf(thisSpaceType, easts) && !tried[findPosition(thisSpaceType, easts)] && !triedAll(tried));
                looped = 0;
                tried[findPosition(thisSpaceType, easts)] = true;

                levelDesign[position] = thisSpaceType;

                eastOpen = false;



                if (!abort && !insideOf(thisSpaceType, norths))
                {
                    northOpen = false;
                }
                else if (position % rows == 0)
                {
                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, souths))
                {
                    southOpen = false;
                }
                else if (position < collums)
                {

                    abort = true;
                }

                if (!abort && !insideOf(thisSpaceType, wests))
                {
                    westOpen = false;
                }
                else if (position % rows == 1)
                {

                    abort = true;
                }


                if (!abort)
                {

                    if (northOpen)
                    {
                        nextPosition = position + collums; ;

                        if (levelDesign[nextPosition] == 0)
                        {
                            northOpen = !assignLevels(north, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], souths))
                        {
                            northOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && southOpen)
                    {
                        nextPosition = position - collums;

                        if (levelDesign[nextPosition] == 0)
                        {
                            southOpen = !assignLevels(south, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], norths))
                        {
                            southOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }

                    if (!abort && westOpen)
                    {
                        nextPosition = position - 1;

                        if (levelDesign[nextPosition] == 0)
                        {
                            westOpen = !assignLevels(east, nextPosition);
                        }
                        else if (insideOf(levelDesign[nextPosition], easts))
                        {
                            westOpen = false;

                        }
                        else
                        {
                            abort = true;
                        }
                    }
                }

            }

            //at this point, if all directions are false, you've got a good position here, return to the last one
            if (!northOpen && !eastOpen && !southOpen && westOpen)
            {
                return true;
            }
            else
            {
                levelDesign[position] = 0;
            }
        }

        return false;

    }

    //returns if you tried all in a list
    bool triedAll(bool [] tried)
    {

        for(int i = 0; i < tried.Length; i++)
        {
            if(!tried[i])
            {
                return false;
            }
        }

        return true;


    }


    int findPosition(int num, int [] list)
    {

        for(int i = 0; i < list.Length; i++)
        {
            if(list[i] == num)
            {
                return i;
            }
        }

        return -1;

    }

    int findNextFalse(int position, bool[] list)
    {

        for(int i = 0; i < list.Length; i++)
        {
            if (!list[i])
            {
                return i;
            }
        }

        return -1;

    }

    bool insideOf(int num, int [] list)
    {

        for(int i = 0; i < list.Length; i++)
        {
            if(num == list[i])
            {
                return true;
            }
        }

        return false;

    }



	
}
