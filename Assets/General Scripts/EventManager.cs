using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    OnItemPickup = 0,
    OnUnitChange = 1,
    OnInteracted = 2,
    OnUpdateTurn = 3,
    OnUnitDeath  = 4,
    OnTakeDamage  = 5,
}

public static class EventManager<T>
{
    private static Dictionary<EventType, System.Action<T>> eventDictionary = new Dictionary<EventType, System.Action<T>>();

    public static void AddListener(EventType type, System.Action<T> function)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }
        eventDictionary[type] += function;
    }

    public static void RemoveListener(EventType type, System.Action<T> function)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            eventDictionary[type] -= function;
        }
    }

    public static void RaiseEvent(EventType type, T arg1)
    {
        eventDictionary[type]?.Invoke(arg1);
    }
}
