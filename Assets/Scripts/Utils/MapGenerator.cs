using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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


        Vector2Int currLoc;
        bool isLocUsed;
        for (int i = 0; i < uniqueLen; i++)
        {
            //1 offset for higher chance to have open space nearby
            isLocUsed = true;
            currLoc = Vector2Int.zero;
            while (isLocUsed)
            {
                currLoc = new Vector2Int(randomizer.GetInt(1, size - 1), randomizer.GetInt(1, size - 1));
                foreach (Vector2Int usedLoc in usedLocs)
                {
                    if (currLoc.Equals(usedLoc))
                    {
                        isLocUsed = true;
                        break;
                    }
                }
                isLocUsed = false;
            }
            Instantiate(uniqueTiles[i], (Vector2) currLoc * 4, Quaternion.identity);
        }

        Instantiate(commonTiles[0], Vector2.zero, Quaternion.identity);
        usedLocs.AddLast(Vector2Int.zero);
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
                GameObject tile = randomizer.GetDouble() < 0.88 ? commonTiles[randomizer.GetInt(0, commonLen)] : rareTiles[randomizer.GetInt(0, rareLen)];
                Instantiate(tile, (Vector2)currLoc * 4, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
