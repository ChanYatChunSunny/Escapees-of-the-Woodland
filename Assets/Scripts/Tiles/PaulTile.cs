using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulTile : Tile
{
    [SerializeField]
    private GameObject paul;

    private DialogueGraph dialogueGraph;
    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(paul, this.transform.position + new Vector3(0.2f, 1, 1), Quaternion.identity);
        Dialogue start = new Dialogue("Hello", "Hello! My name is Paul! I love helping people! Anything I can help you with?", true);
        Dialogue hiAndAnythingNeedHelp = new Dialogue("Hello", "Anything I can help you with?", false);
        Dialogue nothingNeedHelp = new Dialogue("There is nothing I need you to help currently.", "Good, then I will see you later!", true);
        

        Dialogue giveArtifact = new Dialogue("Hmm... Can you give me that artifact you are holding? We need gather 8 of them to escape this place!", "Sure! Here you go!", "gain_artifact 0");
        Dialogue thank = new Dialogue("Thank you so much! We shoul be able to get out of this place soon!", "I am glad to help! I want to leave this place as well. Anything else I can help?", true);
        giveArtifact.Children = new Dialogue[] { thank };
        thank.Children = new Dialogue[] { nothingNeedHelp };


        Dialogue youFool = new Dialogue("It is this kind of 'nice guy' again, right? Well, then just hand me over that artifact if you want to help so much.", "My willingness to help people doesn't mean you can be so rude to me! I would smash this thing before giving it to you!");
        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");
        youFool.Children = new Dialogue[] { noooo };
        Dialogue bye = new Dialogue("Bye.", "", "leave_dialogue", true);
        start.Children = new Dialogue[] { nothingNeedHelp, giveArtifact, youFool, bye };
        hiAndAnythingNeedHelp.Children = new Dialogue[] { nothingNeedHelp, giveArtifact, bye };
        nothingNeedHelp.Children = new Dialogue[] { bye };
        bye.Children = new Dialogue[] { hiAndAnythingNeedHelp };
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
