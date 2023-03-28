using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManagerUI : MonoBehaviour
{
    [SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI turnNumberText;

    private void Start()
    {
        endTurnBtn.onClick.AddListener(() => { TurnManager.Instance.NextTurn(); });

        UpdateTurnText(TurnManager.Instance.GetTurnNumber());
    }

    private void OnEnable()
    {
        EventManager<int>.AddListener(EventType.OnUpdateTurn, UpdateTurnText);
    }

    private void OnDisable()
    {
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, UpdateTurnText);
    }

    private void UpdateTurnText(int turnNumber)
    {
        turnNumberText.text = "Turn " + turnNumber;
    }
}
