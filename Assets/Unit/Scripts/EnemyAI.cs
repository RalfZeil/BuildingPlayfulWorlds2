using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        WaitingForTurn = 0,
        TakingTurn = 1,
        Busy = 2,
    }


    private State state;

    private float timer;
    private float maxTime = 2f;

    public List<Unit> enemies = new();
    private Unit playerUnit;

    private void Start()
    {
        state = State.WaitingForTurn;

        //Get all enemy units and put them in the list
        foreach(Unit unit in GameObject.FindObjectsOfType<Unit>())
        {
            if (!unit.IsPlayerUnit())
            {
                enemies.Add(unit);
            }
            else
            {
                playerUnit = unit;
            }
        }
    }

    private void OnEnable()
    {
        EventManager<int>.AddListener(EventType.OnUpdateTurn, ResetTimer);
    }

    private void OnDisable()
    {
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, ResetTimer);
    }

    private void Update()
    {
        if (TurnManager.Instance.IsPlayerTurn()) { return; }

        switch (state)
        {
            case State.WaitingForTurn:
                break;

            case State.TakingTurn:
                TakeEnemyAIAction();
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    TurnManager.Instance.NextTurn();
                }
                break;

            case State.Busy:
                break;
        }

        
    }

    private void ResetTimer(int turnNumber = 0)
    {
        if (!TurnManager.Instance.IsPlayerTurn())
        {
            state = State.TakingTurn;
            timer = maxTime;
        }
    }

    private void TakeEnemyAIAction()
    {
        foreach(Unit enemy in enemies)
        {
            playerUnit.Interact(enemy);
        }
    }
}
