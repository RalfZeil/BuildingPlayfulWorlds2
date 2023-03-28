using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IInteractable
{
    [SerializeField] private UnitAnimator unitAnimator;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private float stoppingDistance = 0.1f;

    private Vector3 targetPosistion;
    private UnitMovement unitMovement;


    public Tile currentTile { get; private set; }
    [SerializeField] private bool isPlayerUnit;

    public bool isSelected;

    private int maxActionPoints = 2;
    private int actionPoints;

    private void Start()
    {
        unitMovement = new();

        currentTile = GridManager.instance.GetStartTile();

        transform.position = currentTile.transform.position;
        targetPosistion = transform.position;

        actionPoints = maxActionPoints;
    }

    private void OnEnable()
    {
        EventManager<int>.AddListener(EventType.OnUpdateTurn, ResetActionPoints);
    }

    private void OnDisable()
    {
        EventManager<int>.RemoveListener(EventType.OnUpdateTurn, ResetActionPoints);
    }

    public void Move(Vector3 targetPosistion)
    {
        this.targetPosistion = targetPosistion;
    }

    public void GoToTile(Tile destinationTile)
    {
        if (unitMovement.GetNeighbourList(currentTile).Contains(destinationTile))
        {
            Move(destinationTile.transform.position);
            currentTile = destinationTile;
        }
    }

    private void Update()
    {
        if(Vector3.Distance(targetPosistion, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosistion - transform.position).normalized;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

            unitAnimator.SetWalking(true);       
        }
        else
        {
            unitAnimator.SetWalking(false);
        }
    }

    public void RemoveActionPoint(int amount)
    {
        actionPoints -= amount;
    }

    public int GetActionPoints()
    {
        return actionPoints;
    }

    private void ResetActionPoints(int turnNumber)
    {
        actionPoints = maxActionPoints;
    }

    public void Interact(Unit unit)
    {
        if(unit != this)
        {
            UnitActionSystem.instance.HandleSelectedUnit(this);
        }
    }

    public void HighLight()
    {
        
    }
}
