using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickupable, IInteractable
{
    public Texture2D icon;
    public System.Action UseItem;
    public string itemName;

    public void HighLight()
    {

    }

    public void Interact(Unit unit)
    {
        PickUp();
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
