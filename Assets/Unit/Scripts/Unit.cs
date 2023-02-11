using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
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
        }

        if (Input.GetKey(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));
        }
    }
}
