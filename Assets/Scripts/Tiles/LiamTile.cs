using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamTile : Tile
{
    [SerializeField]
    private GameObject liam;
    private DialogueGraph dialogueGraph;
    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(liam, this.transform.position + new Vector3(0.0f, -0.5f, 1), Quaternion.identity);
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
