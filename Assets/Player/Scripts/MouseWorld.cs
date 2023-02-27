using System.Collections;
using System.Collections.Generic;
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

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHitLayerMask, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHitLayerMask.point;
    }
}
