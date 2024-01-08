using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject edgeObj;
    [SerializeField]
    private GameObject nodeObj;

    private TileBase[][] floor;

    // Start is called before the first frame update
    void Start()
    {
        int size = GameData.GetMapSize();
        floor = new TileBase[size][];
        for(int i = 0; i < size; i++)
        {
            floor[i] = new TileBase[size];
        }
        Generate();
    }

    private void Generate() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
