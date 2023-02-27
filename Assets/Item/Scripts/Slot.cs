using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private int slotIndex;
    [SerializeField] private Item currentAssignedItem;

    [SerializeField] private RawImage slotImage;


    public Item GetCurrentAssignedItem()
    {
        return currentAssignedItem;
    }

    public void AssignItem(Item newItem)
    {
        if(currentAssignedItem == null)
        {
            currentAssignedItem = newItem;
        }
    }

    public void SetupItem(Item item)
    {
        slotImage.texture = item.icon;
    }

    public Item EmptySlot()
    {
        Item oldItem = currentAssignedItem;

        currentAssignedItem = null;

        return oldItem;
    }
}
