using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    private const string START_WALKING_PARAMETER = "IsWalking";
    private const string PICKUP_TRIGGER = "Pickup";
    private const string ATTACK_TRIGGER = "Attack";

    [SerializeField] private Animator animator;


    private void Start()
    {
        if (GetComponent<Unit>().IsPlayerUnit())
        {
            EventManager<Item>.AddListener(EventType.OnItemPickup, StartPickupAnimation);
        }

    }

    private void OnDestroy()
    {
        if (GetComponent<Unit>().IsPlayerUnit())
        {
            EventManager<Item>.RemoveListener(EventType.OnItemPickup, StartPickupAnimation);
        }
    }

    public void SetWalking(bool walking)
    {
        animator.SetBool(START_WALKING_PARAMETER, walking);
    }

    public void StartPickupAnimation(Item item)
    {
        animator.SetTrigger(PICKUP_TRIGGER);
    }

    public void StartAttackAnimation()
    {
        animator.SetTrigger(ATTACK_TRIGGER);
    }
}
