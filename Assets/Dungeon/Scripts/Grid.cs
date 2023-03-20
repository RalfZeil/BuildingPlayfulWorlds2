using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;

    private int[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.position = GetWorldPosition(x, z);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    public void SetValue(int x, int y, int value)
    {
        gridArray[x, y] = value;
    }
}
