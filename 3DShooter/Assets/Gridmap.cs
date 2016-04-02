using UnityEngine;
using System.Collections;

public class Gridmap : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public int cubesize;
    ///TODO: ADD TRIGGER FOR BUILDMAP
    void Start()
    {
        int[][,] map = new int[100][,];
        int i = 0, rand1, rand2;
        while (i < 1)
        {
            Debug.Log("%");
            rand1 = Random.Range(4, 11);
            rand2 = Random.Range(4, 11);
            map[i] = new int[rand1, rand2];
            Fillnext(map[i], 0, 0, rand1, rand2);
            BuildMap(map[i], cubesize, rand1, rand2);
            i++;
        }
    }

    void Fillnext(int[,] map, int x, int y, int XMAX, int YMAX)
    {
        int rand1 = Random.Range(0, 1), rand2 = Random.Range(0, 1), rand3 = Random.Range(0, 1), rand4 = Random.Range(0, 1);
        int counter = 0;
        ///Decide how to generate Curr. Using rng, or deterministically
        int curr = map[x, y];
        if (x == 0)
            counter = counter;
        else if (((map[x - 1, y] / 2) % 2 == 1) || ((map[x - 1, y] == 0) && (rand1 == 1)))
            counter += 8;
        if (y == 0)
            counter = counter;
        else if ((map[x, y - 1] % 2 == 1) || ((map[x, y - 1] == 0) && (rand2 == 1)))
            counter += 4;
        if (x == XMAX)
            counter = counter;
        else if (((map[x + 1, y] / 8) == 1) || ((map[x + 1, y] == 0) && (rand3 == 1)))
            counter += 2;
        if (y == YMAX)
            counter = counter;
        else if ((map[x, y + 1] % 8 / 4 == 1) || ((map[x, y + 1] == 0) && (rand4 == 1)))
            counter += 1;
        map[x, y] = counter;

        if (curr % 2 == 1)//down
        {
            if (map[x, y + 1] == 0)
                Fillnext(map, x, y + 1, XMAX, YMAX);
            //Do stuff
        }
        if (curr >= 8)//left
        {
            if (map[x - 1, y] == 0)
                Fillnext(map, x - 1, y, XMAX, YMAX);
        }
        //Do stuff
        if (((curr % 8) / 4) == 1)//up
        {
            if (map[x, y - 1] == 0)
                Fillnext(map, x, y - 1, XMAX, YMAX);
        }
        //DO STUFFFFFF
        if ((((curr % 8) % 4) / 2) == 1)//right
        {
            if (map[x + 1, y] == 0)
                Fillnext(map, x + 1, y, XMAX, YMAX);
        }
        return;
    }

    void BuildMap(int[,] map, int scale, int XDIM, int YDIM)
    {

        int i, j, v;
        GameObject level;
        int rot = 0;


        for (i = 0; i < XDIM; i++)
        {
            for (j = 0; j < YDIM; i++)
            {
                v = map[i, j];
                switch (v)
                {
                    case 1:
                        level = level1;
                        rot = 90;
                        break;

                    case 2:
                        level = level1;
                        rot = 0;
                        break;

                    case 3:
                        level = level2;
                        rot = 90;
                        break;

                    case 4:
                        level = level1;
                        rot = 270;
                        break;

                    case 5:
                        level = level3;
                        rot = 0;
                        break;

                    case 6:
                        level = level2;
                        rot = 0;
                        break;

                    case 7:
                        level = level4;
                        rot = 0;
                        break;

                    case 8:
                        level = level1;
                        rot = 180;
                        break;

                    case 9:
                        level = level2;
                        rot = 180;
                        break;

                    case 10:
                        level = level3;
                        rot = 180;
                        break;

                    case 11:
                        level = level4;
                        rot = 90;
                        break;

                    case 12:
                        level = level2;
                        rot = 270;
                        break;

                    case 13:
                        level = level4;
                        rot = 180;
                        break;

                    case 14:
                        level = level4;
                        rot = 270;
                        break;

                    case 15:
                        level = level5;
                        rot = 0;
                        break;

                    default:
                        level = level6;
                        rot = 90;
                        break;
                }
                Instantiate(level, new Vector3(i * scale, j * scale, 0), Quaternion.Euler(0, rot, 0));


            }
        }
    }
}
