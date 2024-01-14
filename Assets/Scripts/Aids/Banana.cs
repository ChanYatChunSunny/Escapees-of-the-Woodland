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
            playerController.ShowActionText("You ate a banana");
        }
        else
        {
            playerController.ModifyHealth(8);
            playerController.ShowActionText("You ate a banana but slipped over its skin");
            playerController.ModifyHealth(-6);
        }

    }
    public override string GetName()
    {
        return "Banana";
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
