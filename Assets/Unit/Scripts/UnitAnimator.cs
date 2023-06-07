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
        EventManager<Item>.AddListener(EventType.OnItemPickup, StartPickupAnimation);
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
