using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

static public class RandomEx
{

    //var exclude = new HashSet<int>() { 5, 7, 17, 23 };
    static public int GetRandomNumber(HashSet<int> exclude, int min, int count )
    {
        var range = Enumerable.Range(min, count).Where(i => !exclude.Contains(i));
        var rand = new System.Random();
        int index = rand.Next(min, count - exclude.Count);
        return range.ElementAt(index);
    }
}
