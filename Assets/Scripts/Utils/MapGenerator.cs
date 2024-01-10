using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] commonTiles;

    [SerializeField]
    private GameObject[] rareTiles;

    [SerializeField]
    private GameObject[] uniqueTiles;



    // Start is called before the first frame update
    void Start()
    {
        GameData.Init();
        Generate();
    }

    private void Generate()
    {
        int size = GameData.GetMapSize();
        Randomizer randomizer = GameData.GetRandomizer();
        int commonLen = commonTiles.Length;
        int rareLen = rareTiles.Length;

        int uniqueLen = uniqueTiles.Length;
        LinkedList<Vector2Int> usedLocs = new LinkedList<Vector2Int>();


        Vector2Int currLoc = Vector2Int.zero;
        bool isLocUsed;
        //Instantiate(commonTiles[0], Vector2.zero, Quaternion.identity);
        usedLocs.AddLast(currLoc);
        int uniquePtr = 0;
        int randWalkCounter = 0;
        //Generate unique tiles with a guaranteed path connecting them
        while (uniquePtr < uniqueLen)
        {
            isLocUsed = true;
            Direction dir = Direction.up;
            while (isLocUsed)
            {
                isLocUsed = false;
                dir = randomizer.GetDouble() < 0.6 ? dir : (Direction)randomizer.GetInt((int)Direction.up, (int)Direction.left);
                Vector2Int newLoc = currLoc + DirectionOperation.DirectionToVector2Int(dir);
                if (newLoc.x < 0 || newLoc.y < 0 || newLoc.x >= size || newLoc.y >= size)
                {
                    isLocUsed = true;
                    continue;
                }
                foreach (Vector2Int usedLoc in usedLocs)
                {
                    if (newLoc.Equals(usedLoc))
                    {
                        isLocUsed = true;
                        break;
                    }
                }
                //TODO: Add a warning system for failed generation.
                currLoc = newLoc;
            }
            if (randWalkCounter > randomizer.GetInt(6, 12))
            {
                Instantiate(uniqueTiles[uniquePtr], (Vector2)currLoc * 4, Quaternion.identity);
                uniquePtr++;
                randWalkCounter = 0;
            }
            else
            {
                Instantiate(commonTiles[0], (Vector2)currLoc * 4, Quaternion.identity);
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
                foreach (Vector2Int usedLoc in usedLocs)
                {
                    if (currLoc.Equals(usedLoc))
                    {
                        isLocUsed = true;
                        break;
                    }
                }
                if (isLocUsed) { continue; }
                GameObject tile = randomizer.GetDouble() < 0.6 ? commonTiles[randomizer.GetInt(0, commonLen)] : rareTiles[randomizer.GetInt(0, rareLen)];
                Instantiate(tile, (Vector2)currLoc * 4, Quaternion.identity);
            }
        }
        //Generate the border
        for (int i = 0; i < size; i++)
        {
            Instantiate(rareTiles[0], new Vector2(-1, i) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(rareTiles[0], new Vector2(i, -1) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(rareTiles[0], new Vector2(size, i) * 4, Quaternion.identity);
        }
        for (int i = 0; i < size; i++)
        {
            Instantiate(rareTiles[0], new Vector2(i, size) * 4, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
