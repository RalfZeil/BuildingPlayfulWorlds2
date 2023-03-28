using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        EventManager<Unit>.AddListener(EventType.OnUnitChange, UpdatePlayerVisual);
    }

    private void OnDisable()
    {
        EventManager<Unit>.RemoveListener(EventType.OnUnitChange, UpdatePlayerVisual);
    }

    private void UpdatePlayerVisual(Unit unit)
    {
        if( unit == this.unit )
        {
            meshRenderer.enabled = true;
        }

        else
        {
            meshRenderer.enabled = false;
        }
    }
}
