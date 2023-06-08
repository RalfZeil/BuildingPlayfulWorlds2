using UnityEngine;

public class Item : MonoBehaviour, IPickupable, IInteractable
{
    public Texture2D icon;
    public System.Action UseItem;
    public string itemName;
    public int attackDamage;

    public void HighLight()
    {

    }

    public void Interact(Unit unit)
    {
        if (unit.GetActionPoints() > 0)
        {
            PickUp();
            unit.RemoveActionPoint(1);
        }
    }

    public void PickUp()
    {
        EventManager<Item>.RaiseEvent(EventType.OnItemPickup, this);
        gameObject.SetActive(false);
    }

    public void PlaceDown(Vector3 pos)
    {
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
    }

    public void Use()
    {
        UseItem.Invoke();
    }
}
