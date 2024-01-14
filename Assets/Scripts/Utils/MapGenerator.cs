using System;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] walkableTiles;

    [SerializeField]
    private GameObject[] obstacleTiles;

    [SerializeField]
    private GameObject[] uniqueTiles;

    [SerializeField]
    private GameObject badGenUI;

    private const int MaxTrialCount = 256;


    // Start is called before the first frame update
    void Start()
    {
        Settings.Init();
        Generate();
    }

    private void Generate()
    {
        int size = Settings.MapSize;
        Randomizer randomizer = Settings.GetRandomizer();
        int walkableLen = walkableTiles.Length;
        int obstacleLen = obstacleTiles.Length;

        int uniqueLen = uniqueTiles.Length;
        LinkedList<Vector2Int> usedLocs = new LinkedList<Vector2Int>();

        //The first tile is a special tile that handle thep pedestal and the start and success sequences
        Vector2Int currLoc = Vector2Int.zero;
        usedLocs.AddLast(currLoc);
        bool isLocUsed;

        int uniquePtr = 0;
        int randWalkCounter = 0;
        //Generate unique tiles with a guaranteed path connecting them
        while (uniquePtr < uniqueLen)
        {
            isLocUsed = true;
            //initial direction
            Direction dir = randomizer.GetDouble() < 0.5 ? Direction.up: Direction.right;
            int checkCounter = 0;
            //Locate the next tile iteratively
            while (isLocUsed)
            {
                //When the seed is unlucky
                checkCounter++;
                if (checkCounter >= MaxTrialCount)
                {
                    badGenUI.SetActive(true);
                    return;
                }
                isLocUsed = false;
                //70% chance remain original direction, otherwise, pick a new direction
                dir = randomizer.GetDouble()<Math.E%1? dir : (Direction)randomizer.GetInt((int)Direction.up, (int)Direction.left+1);
                Vector2Int newLoc = currLoc + DirectionOperation.DirectionToVector2Int(dir);
                //Border protection
                if (newLoc.x < 0 || newLoc.y < 0 || newLoc.x >= size || newLoc.y >= size)
                {
                    isLocUsed = true;
                    continue;
                }
                //Confirm this tile was never being used
                if (usedLocs.Contains(newLoc))
                {
                    isLocUsed = true;
                    continue;
                }
                currLoc = newLoc;
            }
            //Only place special tiles 
            if (randWalkCounter > randomizer.GetInt(size/6, size/3))
            {
                Instantiate(uniqueTiles[uniquePtr], (Vector2)currLoc * 4, Quaternion.identity);
                uniquePtr++;
                randWalkCounter = 0;
            }
            else
            {
                Instantiate(walkableTiles[0], (Vector2)currLoc * 4, Quaternion.identity);
            }
            randWalkCounter++;
            usedLocs.AddLast(currLoc);
        }
        //Generate the rest of the map
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                isLocUsed = false;
                currLoc = new Vector2Int(i, j);
                //Confirm this tile was never being used
                if (usedLocs.Contains(currLoc))
                {
                    isLocUsed = true;
                    continue;
                }
                GameObject tile = randomizer.GetDouble() < 0.5 ? walkableTiles[randomizer.GetInt(0, walkableLen)] : obstacleTiles[randomizer.GetInt(0, obstacleLen)];
                Instantiate(tile, (Vector2)currLoc * 4, Quaternion.identity);
            }
        }
        //Generate the border
        for (int i = 0; i < size; i++)
        {
            Instantiate(obstacleTiles[0], new Vector2(-1, i) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(obstacleTiles[0], new Vector2(i, -1) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(obstacleTiles[0], new Vector2(size, i) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(obstacleTiles[0], new Vector2(i, size) * 4, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
