using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float timer;
    private float maxTime = 2f;

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

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            TurnManager.Instance.NextTurn();
        }
    }

    private void ResetTimer(int turnNumber = 0)
    {
        timer = maxTime;
    }
}
