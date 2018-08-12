using System.Collections.Generic;

public class Subject {

    List<Observer> observers = new List<Observer>();

    /// <summary>
    /// send notifications if something has happened
    /// </summary>
    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify();
        }
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
}
