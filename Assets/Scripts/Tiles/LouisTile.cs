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
