using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    public static T ChooseFromList<T>(List<T> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
}
