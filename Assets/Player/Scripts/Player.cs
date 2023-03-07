using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IPickupable pickupableObject = hit.collider.gameObject.GetComponent<IPickupable>();

            if(pickupableObject != null)
            {
                if (GameManager.PlayerInputManager.playerInput.PlayerActionMap.Interact.WasPerformedThisFrame())
                {
                    pickupableObject.PickUp();
                }
            }
        }
    }
    

}
