using UnityEngine;
using TMPro;
using System.Collections;

public class SparklingPotion : Aid
{
    public override void ConsumeBy(PlayerController playerController)
    {
        Randomizer randomizer = new Randomizer();
        if (randomizer.GetDouble() < 0.5)
        {
            playerController.ModifyHealth(32);
            playerController.SetActionText("You drank a sparkling potion and it is good");
            playerController.FlashActionText();
        }
        else
        {
            playerController.ModifyHealth(-32);
            if(randomizer.GetDouble() < 0.32)
            {
                playerController.ModifyHealth(-1024);
            }
            playerController.SetActionText("You drank a sparkling potion and it is bad");
            playerController.FlashActionText();
        }

    }
    public override string GetName()
    {
        return "sparkling potion";
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
