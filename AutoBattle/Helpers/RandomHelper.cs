using System;
using System.Collections.Generic;

public static class RandomHelper
{
    public static int GetRandomInt(int minInclusive, int maxExlusive)
    {
        var rand = new Random();
        int value = rand.Next(minInclusive, maxExlusive);
        return value;
    }

    public static List<Character> ShuffleList(List<Character> list)
    {
        int n = list.Count;
        Random rnd = new Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            Character value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}