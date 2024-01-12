using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouisTile : Tile
{

    [SerializeField]
    private GameObject louis;
    private DialogueGraph dialogueGraph;

    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(louis, this.transform.position + new Vector3(0.2f, -0.2f, 1), Quaternion.identity);
        Dialogue start = new Dialogue("Hello", "Hi I am Louis, nice to meet you", true);
        Dialogue greeting = new Dialogue("Nice to meet you! You look so strong!", "Thanks. I used to be a firefighter. Do you need some food? I got a lots", true);
        Dialogue objective = new Dialogue("Thanks, but no need. I'm here to collect all artifacts, so we can escape from the woodland.", "You mean this one ?", "Louis shows his artifact, the dumbbells", false);
        Dialogue getArtifact = new Dialogue("Yes!", "Here you go!", "gain_artifact 1");

        Dialogue greetingWithQuestion = new Dialogue("Nice to meet you, You are strong, Why do you got a giant water bottle?", "Because I am a firefighter and love doing sports so I need a lot of water", true);
        Dialogue louisGetMad; 

    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Interact(PlayerController playerController)
    {
        playerController.DialogueHandler.dialogueGraph = dialogueGraph;
        playerController.DialogueHandler.isInConversation = true;
    }
}
