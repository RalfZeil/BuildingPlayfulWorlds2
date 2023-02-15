using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int minX, maxX, minZ, maxZ;

    public Room(int mixX, int maxX, int minZ, int maxZ)
    {
        this.minX = mixX;
        this.maxX = maxX;
        this.minZ = minZ;
        this.maxZ = maxZ;
    }

    public Vector3Int GetCenter()
    {
        return new Vector3Int(Mathf.RoundToInt(Mathf.Lerp(minX, maxX, 0.5f)), 0, Mathf.RoundToInt(Mathf.Lerp(minX, maxX, 0.5f)));
    }
}
