using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private Slot[] slotsArray;

    private void Start()
    {
        if(Instance == null) { Instance = this; }
        else { Debug.Log("Instance of InventoryManager is already assigned"); }


        EventManager<Item>.AddListener(EventType.OnItemPickup, PickupItem);
    }

    public void PickupItem(Item item)
    {
        foreach(Slot slot in slotsArray)
        {
            if(slot.GetCurrentAssignedItem() == null)
            {
                //Slot is free
                slot.AssignItem(item);
                break;
            }
        }
    }
}
