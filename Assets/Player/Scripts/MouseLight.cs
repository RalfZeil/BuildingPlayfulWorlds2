using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit raycastHit);
        
        transform.position = raycastHit.point;
    }
}
