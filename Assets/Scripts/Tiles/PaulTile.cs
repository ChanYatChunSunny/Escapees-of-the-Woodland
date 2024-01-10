using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulTile : Tile
{
    [SerializeField]
    private GameObject paul;

    private DialogueGraph dialogueGraph;
    private bool startedTalk;
    // Start is called before the first frame update
    public override void Start()
    {
        startedTalk = false;
        Instantiate(paul, this.transform.position + new Vector3(0.2f, 1, 1), Quaternion.identity);
        Dialogue start = new Dialogue("Hello", "Hello! My name is Paul! I love helping people! Anything I can help you with?", true);
        Dialogue anythingNeedHelp = new Dialogue("Hello", "Anything I can help you with?", false);
        Dialogue nothingNeedHelp = new Dialogue("There is nothing I need you to help currently.", "Good, then I will see you later!", false);
        anythingNeedHelp.Children = new Dialogue[] { nothingNeedHelp };
        Dialogue bye = new Dialogue("Bye.", "", true);
        start.Children = new Dialogue[] { nothingNeedHelp, bye };
        nothingNeedHelp.Children = new Dialogue[] { bye };
        bye.Children = new Dialogue[] { anythingNeedHelp };
        dialogueGraph = new DialogueGraph(start);
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Interact(PlayerController playerController)
    {
        if (!startedTalk)
        {
            playerController.DialogueHandler.dialogueGraph = dialogueGraph;
        }
        playerController.DialogueHandler.isInConversation = true;
    }
}
