using Data;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject edgeObj;
    [SerializeField]
    private GameObject nodeObj;

    private MapAxis[][] floor;
    private LinkedList<Vector2Int> nodes;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    private void Generate() 
    {
        int maxSize = GameData.GetMapSize();
        Randomizer randomizer = GameData.GetRandomizer();
        Vector2Int currNode = Vector2Int.zero;
        Vector2Int currCord = Vector2Int.zero;
        nodes.AddLast(currNode);
        int maxSizeDivTwo = maxSize / 2;
        
        bool isUp = false;//Either up or right
        
        while (currNode.x < maxSize || currNode.y < maxSize)
        {
            bool temp = randomizer.GetDouble() > 0.5 ? true : false;
            if(temp != isUp) 
            {
                isUp = temp;

            }
            for (int i = 0; i < maxSizeDivTwo; i++)
            {
                if (isUp)
                {
                    if(currCord.y < maxSize)//Expand up unless it is already at the top position
                    {
                        currCord.Set(currCord.x, currCord.y + 1);
                    }
                    else
                    {
                        currCord.Set(currCord.x + 1, currCord.y);
                    }
                }
                else
                {
                    if (currCord.x < maxSize) //Expand right unless it is already at the rightmost position
                    {
                        currCord.Set(currCord.x + 1, currCord.y);
                    }
                    else
                    {
                        currCord.Set(currCord.x, currCord.y + 1);
                    }
                }
                if(randomizer.GetDouble() > 0.3) { break; }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
