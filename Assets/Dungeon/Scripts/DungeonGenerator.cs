using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TileType
{
    Floor, Wall
}

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] floorPrefabs;
    [SerializeField] private GameObject[] wallPrefabs;


    [SerializeField] private int gridWidth = 100;
    [SerializeField] private int gridHeight = 100;

    [SerializeField] private int minRoomSize = 3;
    [SerializeField] private int maxRoomSize = 10;

    [SerializeField] private int numRooms = 10;

    [SerializeField] private int scale;

    [SerializeField] private Dictionary<Vector3Int, TileType> dungeon = new();

    [SerializeField] private List<Room> roomList = new();
    [SerializeField] private List<GameObject> allInstantiatedPrefabs = new();

    private void Start()
    {
        Generate();
    }


    [ContextMenu("Generate Dungeon")]
    private void Generate()
    {
        //ClearDungeon();
        AllocateRooms();
        ConnectRooms();
        AllocateWalls();
        SpawnDungeon();
    }

    [ContextMenu("Clear Dungeon")]
    private void ClearDungeon()
    {
        var list = dungeon.Values;

        for (int i = allInstantiatedPrefabs.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(allInstantiatedPrefabs[i]);
        }

        dungeon.Clear();
        roomList.Clear();
    }

    private void AllocateRooms()
    {
        for(int i = 0; i < numRooms; i++)
        {
            int minX = Random.Range(0, gridWidth);
            int minZ = Random.Range(0, gridHeight);
            int maxX = minX + Random.Range(minRoomSize, maxRoomSize + 1);
            int maxZ = minZ + Random.Range(minRoomSize, maxRoomSize + 1);

            Room newRoom = new Room(minX, maxX, minZ, maxZ);

            if (CanRoomFitInDungeon(newRoom))
            {
                AddRoomToDungeon(newRoom);
            }
            else
            {
                i --;
            }

        }
    }

    private bool CanRoomFitInDungeon(Room room)
    {
        for (int x = room.minX - 1; x <= room.maxX + 1; x++)
        {
            for (int z = room.minZ - 1; z <= room.maxZ + 1; z++)
            {
                if (dungeon.ContainsKey(new Vector3Int(x, 0, z))) { return false; }
            }
        }
        return true;
    }

    private void AddRoomToDungeon(Room room)
    {
        for (int x = room.minX; x <= room.maxX; x++)
        {
            for (int z = room.minZ; z <= room.maxZ; z++)
            {
                dungeon.Add(new Vector3Int(x, 0, z), TileType.Floor);
            }
        }
        roomList.Add(room);
    }

    private void ConnectRooms()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Room room = roomList[i];
            Room otherRoom = roomList[(i + Random.Range(1, roomList.Count)) % roomList.Count];
            ConnectRooms(room, otherRoom);
        }
    }

    private void ConnectRooms(Room roomOne, Room roomTwo)
    {
        Vector3Int posOne = roomOne.GetCenter();
        Vector3Int posTwo = roomTwo.GetCenter();
        int dirX = posTwo.x > posOne.x ? 1 : -1;
        int x = 0;
        for (x = posOne.x; x != posTwo.x; x += dirX)
        {
            Vector3Int position = new Vector3Int(x, 0, posOne.z);
            if (dungeon.ContainsKey(position)) { continue; }
            dungeon.Add(position, TileType.Floor);
        }

        int dirZ = posTwo.z > posOne.z ? 1 : -1;
        for (int z = posOne.z; z != posTwo.z; z += dirZ)
        {
            Vector3Int position = new Vector3Int(x, 0, z);
            if (dungeon.ContainsKey(position)) { continue; }
            dungeon.Add(position, TileType.Floor);
        }
    }

    public void AllocateWalls()
    {
        var keys = dungeon.Keys.ToList();
        foreach (var kv in keys)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    //if(Mathf.Abs(x) == Mathf.Abs(z)) { continue; }
                    Vector3Int newPos = kv + new Vector3Int(x, 0, z);
                    if (dungeon.ContainsKey(newPos)) { continue; }
                    dungeon.Add(newPos, TileType.Wall);
                }
            }
        }
    }

    private void SpawnDungeon()
    {
        foreach (KeyValuePair<Vector3Int, TileType> kv in dungeon)
        {
            GameObject obj = null;

            GameObject floorPrefab = floorPrefabs[Random.Range(0, floorPrefabs.Length)];
            GameObject wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Length)];

            switch (kv.Value)
            {
                case TileType.Floor: obj = Instantiate(floorPrefab, kv.Key * scale, Quaternion.identity, transform); break;
                case TileType.Wall: obj = Instantiate(wallPrefab, kv.Key * scale, Quaternion.identity, transform); break;
            }
            allInstantiatedPrefabs.Add(obj);
        }
    }



}
