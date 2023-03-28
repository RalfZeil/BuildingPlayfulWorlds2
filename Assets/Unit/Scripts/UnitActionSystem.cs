using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem instance;
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private TextMeshProUGUI actionPointsText;

    private void Awake()
    {
        instance = this;

        selectedUnit.isSelected = true;
    }

    private void Update()
    {
        if (GameManager.PlayerInputManager.playerInput.PlayerActionMap.Interact.WasPerformedThisFrame())
        {
            MouseWorld.InteractWithClickedObject(selectedUnit);
        }

        UpdateActionPoints();
    }

    public void HandleSelectedUnit(Unit newUnit)
    {
        selectedUnit.isSelected = false;

        selectedUnit = newUnit;

        selectedUnit.isSelected = true;

        EventManager<Unit>.RaiseEvent(EventType.OnUnitChange, newUnit);
    }

    private void UpdateActionPoints()
    {
        actionPointsText.text = "Action Points: " + selectedUnit.GetActionPoints();
    }
}
