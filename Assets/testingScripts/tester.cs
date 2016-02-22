using UnityEngine;
using System.Collections;

public class tester : MonoBehaviour {

    randomNumberGenerator rg;
    monkeySort ms;
	void Start () {
        rg = new randomNumberGenerator();
        ms = new monkeySort();

        int[] rgL = new int[100];
        int[] msL = new int[100];

        for(int i = 0; i < 100; i++)
        {
            rgL[i] = rg.generate(0, 100);
        }

        for(int i = 0; i < 100; i++)
        {
            msL[i] = ms.generate(0, 100, 0, 10, 5, 0, 100);
        }

        int rgP = patterns(rgL);
        int msP = patterns(msL);

        Debug.Log(rgP);
        Debug.Log(msP);

    }

    int patterns(int [] list){
        int totalPatterns = 0;
        int totalDuds = 0;
        int total = 0;
        for(int i = 0; i < list.Length; i++)
        {//first position
            bool pat = true;
            for(int j = i; j < list.Length; j++)
            {//second position
                for(int k = 0; (i + k < list.Length) && (j + k < list.Length); k++)
                {//increment limit
                    for (int l = 0; l < k; l++)
                    {//increment implementation
                        if (list[i + l] != list[j + l])
                        {//comparison
                            pat = false;
                        }
                    }
                    //check here for pattern as here is where the incrementation is done being implemented
                    if (pat)
                    {//it made it through all the checks, there must be a pattern
                        totalPatterns++;
                        total++;
                    }else
                    {//reset
                        pat = true;
                        totalDuds++;
                        total++;
                    }
                }
            }
        }

        return total;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
