using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;


public class GameData
{
    private static Randomizer randomizer;
    private static int mapSize;
    private static bool isInitialized = false;

    public static Randomizer GetRandomizer()
    {
        return randomizer;
    }
    public static void SetMapSize(int mapSize)
    {
        GameData.mapSize = mapSize;
    }

    public static int GetMapSize()
    {
        return mapSize;
    }

    public static void Init()
    {
        if (isInitialized) { return; }
        randomizer = new Randomizer();
        isInitialized = true;
    }
}

