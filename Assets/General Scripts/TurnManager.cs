using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    private int turnNumber = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void NextTurn()
    {
        turnNumber++;
        EventManager<int>.RaiseEvent(EventType.OnUpdateTurn, turnNumber);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }
}
