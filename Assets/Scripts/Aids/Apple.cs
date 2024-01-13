using UnityEngine;
using TMPro;
using System.Collections;

public class Apple : Aid
{
    public override void ConsumeBy(PlayerController playerController)
    {
        playerController.ModifyHealth(10);
        playerController.SetActionText("You ate an apple");
        playerController.FlashActionText();

    }
    public override string GetName()
    {
        return "Apple";
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
