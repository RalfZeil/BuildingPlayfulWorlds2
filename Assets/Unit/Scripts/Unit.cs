using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    private const string START_WALKING_PARAMETER = "IsWalking";

    [SerializeField] private Animator unitAnimator;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private float stoppingDistance = 0.1f;

    private Vector3 targetPosistion;

    private void Move(Vector3 targetPosistion)
    {
        this.targetPosistion = targetPosistion;
    }

    private void Update()
    {
        if(Vector3.Distance(targetPosistion, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosistion - transform.position).normalized;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

            unitAnimator.SetBool(START_WALKING_PARAMETER, true);         
        }
        else
        {
            unitAnimator.SetBool(START_WALKING_PARAMETER, false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }
}
