using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Unit : MonoBehaviour, IInteractable
{
    [SerializeField] private UnitAnimator unitAnimator;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private float stoppingDistance = 0.1f;

    private Vector3 targetPosistion;
    private UnitMovement unitMovement;
    private UnitHealthSystem unitHealthSystem;

    [SerializeField] private int attackDamage = 10;

    public Tile currentTile;
    [SerializeField] private bool isPlayerUnit;

    public bool isSelected;

    [SerializeField] private int maxActionPoints = 2;
    private int actionPoints;


    private void Start()
    {
        unitMovement = new();
        unitHealthSystem = GetComponent<UnitHealthSystem>();

        if (isPlayerUnit)
        {
            currentTile = GridManager.instance.GetStartTile();
        }
        
        transform.position = currentTile.transform.position;
        targetPosistion = transform.position;

        actionPoints = maxActionPoints;
    }

    private void OnEnable()
    {
        EventManager<int>.AddListener(EventType.OnUpdateTurn, ResetActionPoints);
        EventManager<Unit>.AddListener(EventType.OnUnitDeath, OnUnitDeath);

        if (isPlayerUnit)
        {
            EventManager<Item>.AddListener(EventType.OnItemPickup, SetAttackDamageFromItem);
        }
    }

    private void OnUnitDeath(Unit unit)
    {
        if (unit.isPlayerUnit)
        {
            SceneManager.LoadScene(3);
        }

        if (unit == this)
        {
            Debug.Log("Dieded");
        }
        else
        {
            Debug.Log("Gaming");
        }
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
            RemoveActionPoint(1);
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
        if(!isPlayerUnit && !TurnManager.Instance.IsPlayerTurn() ||
            isPlayerUnit && TurnManager.Instance.IsPlayerTurn())
        {
            actionPoints = maxActionPoints;
        }
    }

    public void Interact(Unit unit)
    {
        if(unit != this)
        {
            if (unitMovement.GetNeighbourList(currentTile).Contains(unit.currentTile))
            {
                if(unit.actionPoints > 0)
                {
                    //Other unit that interacts attacks
                    unit.unitAnimator.StartAttackAnimation();
                    unit.RemoveActionPoint(1);
                    unit.transform.forward = (transform.position - unit.transform.position).normalized;

                    //This unit gets damage
                    unitHealthSystem.Damage(unit.attackDamage);

                    EventManager<Unit>.RaiseEvent(EventType.OnTakeDamage, this);
                    
                }
            }
        }
    }

    public void AttackUnit(Unit unit)
    {
        if (unitMovement.GetNeighbourList(currentTile).Contains(unit.currentTile))
        {
            if (unit.actionPoints > 0)
            {
                //Other unit that interacts attacks
                unit.unitAnimator.StartAttackAnimation();
                unit.RemoveActionPoint(1);
                unit.transform.forward = (transform.position - unit.transform.position).normalized; ;

                //This unit gets damage
                unitHealthSystem.Damage(10);

            }
        }
    }

    public void HighLight()
    {
        
    }

    public bool IsPlayerUnit()
    {
        return isPlayerUnit;
    }

    private void SetAttackDamageFromItem(Item item)
    {
        if(item.attackDamage > attackDamage)
        {
            attackDamage = item.attackDamage;
        }
    }
}
