using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class NavigationList<T> : List<T>
{
    public int CurrentIndex
    {
        get => _currentIndex.Clamp(0, Count - 1);
        set => _currentIndex = value.Clamp(0, Count - 1);
    }

    private int _currentIndex = 0;

    public T First => Count == 0 ? default : this[CurrentIndex = 0];
    public T Prev => Count == 0 ? default : this[(--_currentIndex).Clamp(0, Count - 1)];
    public T Current => Count == 0 ? default : this[CurrentIndex];
    public T Next => Count == 0 ? default : this[(++_currentIndex).Clamp(0, Count - 1)];
    public T Last => Count == 0 ? default : this[(Count - 1).Clamp(0, Count - 1)];
    public T Rand => Count == 0 ? default : this[_currentIndex = UnityEngine.Random.Range(0, Count)];

    public NavigationList() : base()
    {
    }

    public NavigationList(IEnumerable<T> collection) : base(collection)
    {
    }


    public T FindNext(Predicate<T> predicate)
    {
        try
        {
            CurrentIndex = FindIndex(predicate);
        }
        catch (Exception e)
        {
            Debug.LogWarning($"FindNext Error ] 해당 데이터가 없음 : {e}");
        }

        return Next;
    }

    public T FindPrev(Predicate<T> predicate)
    {
        try
        {
            CurrentIndex = FindLastIndex(predicate);
        }
        catch (Exception e)
        {
            Debug.LogWarning($"FindPrev Error ] 에 해당 데이터가 없음 : {e}");
        }

        return Prev;
    }
}

