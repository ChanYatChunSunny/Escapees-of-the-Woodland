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
        Dialogue knowHer = new Dialogue("Yes, you are that famous video creator who got famous by shooting a vlog to record yourself overcoming the Himalayas successfully", "Yes, that's me! Ha ha.", true);
        Dialogue excited = new Dialogue("You are my idol! I am coming to collect all 8 artifacts so everyone here can escape from here. Wait is that the latest camera!!", "You know camera?", true);
        Dialogue knowPhoto = new Dialogue("Yes, I love taking photos, wishing to try and use this camera one day!", "You said that you want to use it. Here have a chance, if you promise to be the cameraman and help me record all my experience in this woodland. I'll give the artifact to you.", true);
        Dialogue gainArtifact = new Dialogue("sure!", "Here you go", "gain_artifact 6", true);
        Dialogue brokeCamera = new Dialogue("Of course, can I try and use the camera?", "What the heck!! ( Player is too excited and slip off to the ground, the camera broke)", "fail_game");
        Dialogue dontKnowHer = new Dialogue("Sorry, I don't know you", "For real?! (Elisa feels extremely embarrassed by digging a hole and hiding into it)", "fail_game");
        Dialogue wrongANswer = new Dialogue("Yes, you are the one who created a video and traveled the world in 80 days", "What, do you really know me? That's is shot by my biggest rival Elsa!", "fail_game");
        Dialogue takePhoto = new Dialogue("Can we take a photo?", "player and Elisa talk together happily and later get the artifact successfully", "gain_artifact 6");
        start.Children = new Dialogue[] {knowHer, dontKnowHer, wrongANswer};
        knowHer.Children = new Dialogue[] {excited, takePhoto};
        excited.Children = new Dialogue[] {knowPhoto};
        knowPhoto.Children = new Dialogue[] {brokeCamera, gainArtifact};
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
