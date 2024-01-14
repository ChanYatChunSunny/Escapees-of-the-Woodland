using UnityEngine;

public class LandTile : Tile
{
    [SerializeField]
    private GameObject[] aids;
    // Start is called before the first frame update
    public override void Start()
    {
        //The spawning of aids should not be affected by the main RNG (because loot is not part of the aids)
        Randomizer randomizer = new Randomizer();
        while(randomizer.GetDouble() < 0.128)
        {
            float x = transform.position.x + (float)(randomizer.GetDouble() < 0.5 ? randomizer.GetDouble() : -randomizer.GetDouble());
            float y = transform.position.y + (float)(randomizer.GetDouble() < 0.5 ? randomizer.GetDouble() : -randomizer.GetDouble());
            Instantiate(aids[randomizer.GetInt(0, aids.Length)], new Vector2(x, y), Quaternion.identity);
        }

    }

    // Update is called once per frame
    public override void Update()
    {

    }
}
