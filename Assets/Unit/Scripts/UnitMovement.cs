using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement
{

    public List<Tile> GetNeighbourList(Tile currentTile)
    {
        List<Tile> neighbours = new List<Tile>();

        if (currentTile.gridPosX - 1 >= 0)
        {
            //Left
            if (GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ) != null)
            {
                neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ));
            }

            //Left Down
            if (GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ - 1) != null)
            {
                if (currentTile.gridPosZ - 1 >= 0) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ - 1));
            }

            //Left Up
            if (GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ + 1) != null)
            {
                if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ + 1));
            }

        }

 
        if (currentTile.gridPosX + 1 < GridManager.instance.highestX)
        {
            //Right
            if (GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ) != null)
            {
                neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ));
            }

            //Right Down
            if (GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ - 1) != null)
            {
                if (currentTile.gridPosZ - 1 >= 0) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ - 1));
            }

            //Left Up
            if (GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ + 1) != null)
            {
                if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ + 1));
            }
        }

        //Down
        if (currentTile.gridPosZ - 1 >= 0 && GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ - 1) != null) 
        { 
            neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ - 1)); 
        }

        //Up
        if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ && GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ + 1) != null) 
        {
            neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ + 1)); 
        }

        return neighbours;
    }
}
