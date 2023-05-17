using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManagerUI : MonoBehaviour
{
    [SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI turnNumberText;
    [SerializeField] private GameObject enemyTurnText;

    private void Start()
    {
        endTurnBtn.onClick.AddListener(() => { TurnManager.Instance.NextTurn(); });

        UpdateTurnText(TurnManager.Instance.GetTurnNumber());
        UpdateEnemyTurnVisual();
    }

    private void OnEnable()
    {
        EventManager<int>.AddListener(EventType.OnUpdateTurn, UpdateTurnText);
        EventManager<int>.AddListener(EventType.OnUpdateTurn, UpdateEnemyTurnVisual);
        EventManager<int>.AddListener(EventType.OnUpdateTurn, UpdateEndTurnButtonVisibility);
    }

    private void OnDisable()
    {
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, UpdateTurnText);
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, UpdateEnemyTurnVisual);
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, UpdateEndTurnButtonVisibility);
    }

    private void UpdateTurnText(int turnNumber)
    {
        turnNumberText.text = "Turn " + turnNumber;
    }

    private void UpdateEnemyTurnVisual(int turnNumber = 0)
    {
        enemyTurnText.SetActive(!TurnManager.Instance.IsPlayerTurn());
    }

    private void UpdateEndTurnButtonVisibility(int turnNumber = 0)
    {
        endTurnBtn.gameObject.SetActive(TurnManager.Instance.IsPlayerTurn());
    }
}
