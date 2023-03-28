using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    //private const int MOVE_STRAIGHT_COST = 10;
    //private const int MOVE_DIAGONAL_COST = 14;

    //private List<Tile> openList;
    //private List<Tile> closedList;

    //public List<Tile> FindPath(int startX, int startZ, int endX, int endZ)
    //{
    //    Tile startTile = GridManager.instance.GetTile(startX, startZ);
    //    Tile endTile = GridManager.instance.GetTile(endX, endZ);

    //    openList = new List<Tile> { startTile };
    //    closedList = new List<Tile>();

    //    for (int x = 0; x < GridManager.instance.highestX; x++)
    //    {
    //        for (int z = 0; z < GridManager.instance.highestZ; z++)
    //        {
    //            Tile tile = GridManager.instance.GetTile(x, z);
    //            tile.gCost = int.MaxValue;
    //            tile.CalculateFCost();
    //            tile.cameFromTile = null;

    //        }
    //    }

    //    startTile.gCost = 0;
    //    startTile.hCost = CalculateDistanceCost(startTile, endTile);
    //    startTile.CalculateFCost();

    //    while(openList.Count > 0)
    //    {
    //        Tile currentTile = GetLowestFCostTile(openList);
    //        if(currentTile == endTile)
    //        {
    //            //Reached final tile
    //            return CalculatePath(endTile);
    //        }

    //        openList.Remove(currentTile);
    //        closedList.Add(currentTile);

    //        foreach(Tile neighbourTile in GetNeighbourList(currentTile))
    //        {
    //            if(closedList.Contains(neighbourTile)) { continue; }

    //            int tentativeGCost = currentTile.gCost + CalculateDistanceCost(currentTile, neighbourTile);

    //            if(tentativeGCost < neighbourTile.gCost)
    //            {
    //                neighbourTile.cameFromTile = currentTile;
    //                neighbourTile.gCost = tentativeGCost;
    //                neighbourTile.hCost = CalculateDistanceCost(neighbourTile, endTile);
    //                neighbourTile.CalculateFCost();

    //                if (!openList.Contains(neighbourTile))
    //                {
    //                    openList.Add(neighbourTile);
    //                }
    //            }
    //        }
    //    }

    //    //Out of nodes on the openList
    //    return null;
    //}

    //private List<Tile> GetNeighbourList(Tile currentTile)
    //{
    //    List<Tile> neighbours = new List<Tile>();

    //    if(currentTile.gridPosX - 1 >= 0)
    //    {
    //        //Left
    //        neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ));

    //        //Left Down
    //        if(currentTile.gridPosZ -1 >= 0) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ - 1));

    //        //Left Up
    //        if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX - 1, currentTile.gridPosZ + 1));
    //    }

    //    if (currentTile.gridPosX + 1 < GridManager.instance.highestX)
    //    {
    //        //Right
    //        neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ));

    //        //Right Down
    //        if (currentTile.gridPosZ - 1 >= 0) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ - 1));

    //        //Left Up
    //        if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ) neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX + 1, currentTile.gridPosZ + 1));
    //    }

    //    //Down
    //    if(currentTile.gridPosZ - 1 >= 0) { neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ - 1)); }

    //    //Up
    //    if (currentTile.gridPosZ + 1 < GridManager.instance.highestZ) { neighbours.Add(GridManager.instance.GetTile(currentTile.gridPosX, currentTile.gridPosZ + 1)); }

    //    return neighbours;
    //}

    //private List<Tile> CalculatePath(Tile endTile)
    //{
    //    List<Tile> path = new();

    //    path.Add(endTile);
    //    Tile currentTile = endTile;
    //    while(currentTile.cameFromTile != null)
    //    {
    //        path.Add(currentTile.cameFromTile);
    //        currentTile = currentTile.cameFromTile;
    //    }
    //    path.Reverse();
    //    return path;
    //}

    //private int CalculateDistanceCost(Tile a, Tile b)
    //{
    //    int xDistance = Mathf.Abs(a.gridPosX - b.gridPosX);
    //    int zDistance = Mathf.Abs(a.gridPosZ - b.gridPosZ);
    //    int remaining = Mathf.Abs(xDistance - zDistance);
    //    return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, zDistance) + MOVE_DIAGONAL_COST * remaining;
    //}

    //private Tile GetLowestFCostTile(List<Tile> tileList)
    //{
    //    Tile lowestFCostTile = tileList[0];
    //    for (int i = 0; i < tileList.Count; i++)
    //    {
    //        if (tileList[i].fCost > lowestFCostTile.fCost)
    //        {
    //            lowestFCostTile = tileList[i];
    //        }
    //    }

    //    return lowestFCostTile;
    //}
    
}
