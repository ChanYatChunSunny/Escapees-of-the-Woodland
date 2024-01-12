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
        Dialogue acceptFood = new Dialogue("Yes, please", "Here you go", "player gain 10 health from the food given by Louis", false); 
        Dialogue greetingWithQuestion = new Dialogue("Nice to meet you, You are strong, Why do you got a giant water bottle?", "Because I am a firefighter and love doing sports so I need a lot of water", true);
        Dialogue louisGetMad = new Dialogue("I see. Then you should have a lots of food. Can I get some from you", "What?! (Louis feels like he is being treated as a tool by players)\n(Louis gets angry and don't want to talk to player anymore )", "fail_game");
        Dialogue stealFood = new Dialogue("You got a lot of food! (Steal his food)", "What are you doing!! (player is punched by the firefighter)", "fail_game_injury");
        Dialogue thank = new Dialogue("Thank you!", "Come and find me if you need help. See you.", "leave_dialogue", true);
        start.Children = new Dialogue[] {greeting, greetingWithQuestion, stealFood};
        greeting.Children = new Dialogue[] {objective, acceptFood};
        objective.Children = new Dialogue[] {getArtifact};
        acceptFood.Children = new Dialogue[] {thank};
        greetingWithQuestion.Children = new Dialogue[] {louisGetMad};
        dialogueGraph = new DialogueGraph(start);

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
