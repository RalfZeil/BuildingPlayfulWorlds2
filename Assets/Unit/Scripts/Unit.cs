using UnityEngine;

public class Unit : MonoBehaviour
{
    

    [SerializeField] private UnitAnimator unitAnimator;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private float stoppingDistance = 0.1f;

    private Vector3 targetPosistion;

    public void Move(Vector3 targetPosistion)
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

            unitAnimator.SetWalking(true);       
        }
        else
        {
            unitAnimator.SetWalking(false);
        }

        if (GameManager.PlayerInputManager.playerInput.PlayerActionMap.Interact.WasPerformedThisFrame())
        {
            MouseWorld.InteractWithClickedObject(this);
        }
    }
}
