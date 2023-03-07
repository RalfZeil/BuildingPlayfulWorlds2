using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickupable
{
    public Texture2D icon;
    public System.Action UseItem;
    public string itemName;

    public void PickUp()
    {
        EventManager<Item>.RaiseEvent(EventType.OnItemPickup, this);
    }

    public void Use()
    {
        UseItem.Invoke();
    }
}
