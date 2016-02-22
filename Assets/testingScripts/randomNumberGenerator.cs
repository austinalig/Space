using System;

public class randomNumberGenerator {
    Random rnd;
    public randomNumberGenerator()
    {
        rnd = new Random();
    }

    public int generate(int min, int max)
    {
        return rnd.Next(min, max);
    }
	
}
