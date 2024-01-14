public class SparklingPotion : Aid
{
    public override void ConsumeBy(PlayerController playerController)
    {
        Randomizer randomizer = new Randomizer();
        if (randomizer.GetDouble() < 0.5)
        {
            playerController.ModifyHealth(32);
            playerController.ShowActionText("You drank a sparkling potion and it is good");
        }
        else
        {
            playerController.ModifyHealth(-32);
            if(randomizer.GetDouble() < 0.32)
            {
                playerController.ModifyHealth(-1024);
            }
            playerController.ShowActionText("You drank a sparkling potion and it is bad");
        }

    }
    public override string GetName()
    {
        return "Sparkling Potion";
    }

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }



}
