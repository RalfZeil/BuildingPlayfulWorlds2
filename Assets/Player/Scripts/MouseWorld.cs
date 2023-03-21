using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;
    [SerializeField] private LayerMask itemLayerMask;


    private void Awake()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        IInteractable interactable = GetInteractableObject();

        interactable?.HighLight();
    }

    public static void InteractWithClickedObject(Unit unit)
    {
        IInteractable interactable = GetInteractableObject();

        interactable?.Interact(unit);
    }

    private static IInteractable GetInteractableObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue);

        try
        {
            IInteractable interactable = raycastHit.transform.GetComponent<IInteractable>();

            if (interactable != null) { return interactable; }
            else { return null; }
        }
        catch
        {
            return null;
        }    
    }
}
