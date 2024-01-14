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
        Dialogue greeting = new Dialogue("Nice to meet you! You look so strong!", "Thanks. I used to be a firefighter. Do you need some food? I got a lot of them.", true);
        Dialogue objective = new Dialogue("Thanks, but I'm here to collect all artifacts to rescue everyone from the Woodland.", "You mean this one?", false);
        Dialogue getArtifact = new Dialogue("Yes!", "Here you go!", "gain_artifact 2");
        Dialogue acceptFood = new Dialogue("Yes, please", "Here you go", "change_health 10", false);
        Dialogue btw = new Dialogue("By the way, I need to collect an artifact from you to rescue us and the everyone else fom this palce!", "You mean this?");
        Dialogue allTheFood = new Dialogue("That is not enough! Give me all the food! You are a firefighter then you should save my tummy!", "You are rude! (Louis feels like he is being treated as a tool by the player and don't want to talk to player anymore)");
        Dialogue greetingWithQuestion = new Dialogue("Nice to meet you, You are strong, Why do you got a giant water bottle?", "Because I am a firefighter and love doing sports so I need a lot of water", true);
        Dialogue louisGetMad = new Dialogue("I see. Then you should have a lots of food. Go get me some food!", "What?! (Louis feels like he is being treated as a tool by the player and don't want to talk to player anymore)");
        Dialogue stealFood = new Dialogue("You got a lot of food! (Steal his food)", "What are you doing!! (player is punched by Louis)");
        Dialogue thank = new Dialogue("Thank you!", "Come and find me if you need help. See you.", "leave_dialogue", true);
        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");
        allTheFood.Children = new Dialogue[] { noooo };
        louisGetMad.Children = new Dialogue[] { noooo };
        Dialogue nooooByHit = new Dialogue("Noooo!", "", "fail_game_injury");
        stealFood.Children = new Dialogue[] {nooooByHit };
        start.Children = new Dialogue[] {greetingWithQuestion, stealFood, greeting };
        greeting.Children = new Dialogue[] {objective, acceptFood};
        objective.Children = new Dialogue[] {getArtifact};
        getArtifact.Children = new Dialogue[] {thank};
        acceptFood.Children = new Dialogue[] { btw, allTheFood };
        btw.Children = new Dialogue[] { getArtifact };
        greetingWithQuestion.Children = new Dialogue[] {louisGetMad, btw };
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
