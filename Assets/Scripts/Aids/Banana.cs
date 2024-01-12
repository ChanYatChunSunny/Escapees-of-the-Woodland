using UnityEngine;
using TMPro;
using System.Collections;

public class Banana : Aid
{
    public override void ConsumeBy(PlayerController playerController)
    {
        Randomizer randomizer = new Randomizer();
        if (randomizer.GetDouble() < 0.5)
        {
            playerController.ModifyHealth(8);
            playerController.SetActionText("You ate a banana");
            playerController.FlashActionText();
        }
        else
        {
            playerController.ModifyHealth(8);
            playerController.SetActionText("You ate a banana but slipped over its skin");
            playerController.ModifyHealth(-6);
            playerController.FlashActionText();
        }

    }
    public override string GetName()
    {
        return "banana";
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
