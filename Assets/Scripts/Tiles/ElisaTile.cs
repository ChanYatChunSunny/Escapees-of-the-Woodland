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
