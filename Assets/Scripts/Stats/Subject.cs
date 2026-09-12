using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    private static readonly List<IObserver> observers = new List<IObserver>();
    int numObservers;

    public void AddObserver(IObserver observer)
    {
        if (observer == null) return;

        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observer == null) return;
        observers.Remove(observer);
    }

    public void Notify(StatsData data)
    {
        var safeCopy = new List<IObserver>(observers);
        foreach (var observer in safeCopy)
        {
            observer.OnNotify(data);
        }
    }

    public void ClearObservers() { observers.Clear(); }

    public int ObserverCount => observers.Count;
}
