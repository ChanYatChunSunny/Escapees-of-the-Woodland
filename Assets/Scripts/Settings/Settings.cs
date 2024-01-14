public class Settings
{
    private static Randomizer randomizer;
    private static int mapSize;

    public static int MapSize
    {
        get { return mapSize; }
        set {
            if (value < 16) 
            {
                mapSize = 16; 
            }
            else
            {
                mapSize = value;
            }
        
        }
    }

    private static bool isInitialized = false;
    private static float musicVol;

    public static float MusicVol
    {
        get { return musicVol; }
        set {
            if (value > 1)
            {
                musicVol = 1;
            }else if(value < 0)
            {
                musicVol = 0;
            }
            else
            {
                musicVol = value;
            }
        }
    }


    public static Randomizer GetRandomizer()
    {
        return randomizer;
    }

    public static void Init()
    {
        if (isInitialized) { return; }
        randomizer = new Randomizer();
        mapSize = 16;
        MusicVol = 0.5f;
        isInitialized = true;
    }
}

