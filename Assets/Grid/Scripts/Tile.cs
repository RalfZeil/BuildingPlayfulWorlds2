using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IInteractable
{
    [SerializeField] public bool startTile;

    public int gridPosX;
    public int gridPosZ;

    private bool highLighted;
    private Material mat;

    [SerializeField] private float highLightedAlpha = 0.05f;
    private Color color = new Color(1, 1, 1, 0);

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    public void Interact(Unit unit)
    {
        unit.GoToTile(this);
        Debug.Log("Moving to Tile");
    }

    public void HighLight()
    {
        highLighted = true;
    }

    private void Update()
    {
        if (highLighted)
        {
            color.a = highLightedAlpha;
            mat.color = color;
        }
        else
        {
            color.a = 0f;
            mat.color = color;
        }

        highLighted = false;
    }
}
