using TMPro;
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
        if (TurnManager.Instance.IsPlayerTurn())
        {
            if (GameManager.PlayerInputManager.playerInput.PlayerActionMap.Interact.WasPerformedThisFrame())
            {
                MouseWorld.InteractWithClickedObject(selectedUnit);
            }
        }

        UpdateActionPoints();
    }

    public void HandleSelectedUnit(Unit newUnit)
    {
        if(newUnit.IsPlayerUnit() == false)
        {
            return;
        }

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
