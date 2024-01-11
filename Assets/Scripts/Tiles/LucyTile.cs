using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyTile : Tile
{
    [SerializeField]
    private GameObject lucy;
    private DialogueGraph dialogueGraph;
    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(lucy, this.transform.position, Quaternion.identity);
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
