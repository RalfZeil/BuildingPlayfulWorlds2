using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineFreeLook cmf;

    private void Awake()
    {
        cmf = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable()
    {
        EventManager<Unit>.AddListener(EventType.OnUnitChange, ChangeUnitFollow);
    }

    private void OnDisable()
    {
        EventManager<Unit>.RemoveListener(EventType.OnUnitChange, ChangeUnitFollow);
    }

    public void ChangeUnitFollow(Unit newUnit)
    {
        cmf.Follow = newUnit.transform;
        cmf.LookAt = newUnit.transform;
    }
}
