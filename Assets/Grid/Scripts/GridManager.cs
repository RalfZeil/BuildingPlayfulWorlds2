using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public int highestX { get; private set; }
    public int highestZ { get; private set; }

    private Tile[] tiles;
    private Tile[,] grid;

    //Distance difference between 2 neighboring tiles
    private float tileStep = 3f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tiles = FindObjectsOfType<Tile>();

        AssignTilePosistions();
    }

    private void AssignTilePosistions()
    {
        float lowestXPos  = float.MaxValue;
        float highestXPos = float.MinValue;
        float lowestZPos  = float.MaxValue;
        float highestZPos = float.MinValue;

        //Finding the lowest and highest positions
        foreach(Tile tile in tiles)
        {
            if (tile.transform.position.x < lowestXPos)  { lowestXPos = tile.transform.position.x; }
            if (tile.transform.position.x > highestXPos) { highestXPos = tile.transform.position.x; }
            if (tile.transform.position.z < lowestZPos)  { lowestZPos = tile.transform.position.z; }
            if (tile.transform.position.z > highestZPos) { highestZPos = tile.transform.position.z; }
        }

        float currentValueX = lowestXPos;
        float currentValueZ = lowestZPos;
        int currentStep = 0;

        //Setting the grid position for all the tiles
        for (int i = 0; currentValueX <= highestXPos; i++)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.transform.position.x == currentValueX) 
                { 
                    tile.gridPosX = currentStep;
                    highestX = currentStep;
                }

                if (tile.transform.position.z == currentValueZ) 
                { 
                    tile.gridPosZ = currentStep;
                    highestZ = currentStep;
                }       
            }
            currentValueX += tileStep;
            currentValueZ += tileStep;
            currentStep += 1;
        }

        grid = new Tile[(int)currentValueX, (int)currentValueZ];

        //Filling the 2D Array with the tiles
        foreach(Tile tile in tiles)
        {
            grid[tile.gridPosX, tile.gridPosZ] = tile;
        }
    }

    public Tile GetTile(int x, int y)
    {
        if (grid[x, y] == null)
        {
            return null;
        }
        return grid[x, y];
    }

    public Tile GetStartTile()
    {
        foreach(Tile tile in tiles)
        {
            if(tile.startTile == true)
            {
                return tile;
            }
        }

        return null;
    }
}
