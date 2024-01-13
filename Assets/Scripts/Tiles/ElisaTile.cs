using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElisaTile : Tile
{
    [SerializeField]
    private GameObject elisa;
    private DialogueGraph dialogueGraph;
    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(elisa, this.transform.position + new Vector3(0.1f, 0.3f, 1), Quaternion.identity);
        Dialogue start = new Dialogue("Hi", "Hi I am  Elisa, I bet you do know me!", true);
        Dialogue knowHer = new Dialogue("Yes, you are that famous vlogger who got famous by shooting a vlog to record yourself overcoming the Himalayas successfully", "Yes, that's me! Ha ha.", true);
        Dialogue excited = new Dialogue("You are my idol! I am coming to collect some artifacts so... Wait is that the latest recorder!!", "You know about recorder?", true);
        Dialogue knowVideo = new Dialogue("Yes, I love taking videos, I wish to try and use this recorder one day!", "You said that you want to use it. Here have a chance, if you promise to be the cameraman and help me record all my experience in this woodland. I'll give the artifact to you.", true);
        Dialogue agree = new Dialogue("Yes!", "Thank you", true);

        Dialogue brokeCamera = new Dialogue("Of course, give me the recorder!", "Be gentle! (The recorder accidentally fall to the ground, Elisa hate you now)");
        Dialogue dontKnowHer = new Dialogue("Sorry, I don't know you", "For real?! (Elisa feels extremely embarrassed and refused to talk to the player anymore)");
        Dialogue wrongAns = new Dialogue("Yes, you are the one who created a video and traveled the world in 80 days", "What, do you really know me? That's is shot by my biggest rival Elsa!");

        Dialogue takePhoto = new Dialogue("Can we take a photo?", "Sure, my fan.");

        Dialogue askArtifact = new Dialogue("Anyway, I need an artifact to get us all out of here.", "You mean this?");
        Dialogue thank = new Dialogue("Yes! Thank you!", "", "gain_artifact 4");
        
        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");
        start.Children = new Dialogue[] {knowHer, dontKnowHer, wrongAns};
        knowHer.Children = new Dialogue[] {excited, takePhoto};
        excited.Children = new Dialogue[] {knowVideo};
        knowVideo.Children = new Dialogue[] {brokeCamera, agree};
        brokeCamera.Children = new Dialogue[] { noooo };
        dontKnowHer.Children = new Dialogue[] { noooo };
        wrongAns.Children = new Dialogue[] { noooo };
        agree.Children = new Dialogue[] { askArtifact };
        takePhoto.Children = new Dialogue[] { takePhoto };
        askArtifact.Children = new Dialogue[] { thank };

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
