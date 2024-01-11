using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnabelleTile : Tile
{
    [SerializeField]
    private GameObject annabelle;
    private DialogueGraph dialogueGraph;

    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(annabelle, this.transform.position, Quaternion.identity);
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
