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
        Dialogue start = new Dialogue("Hi", "Who are you... Stay away from me... I only know Louis, the one who save me before", "Annabelle hides herself behind a shield", true);
        Dialogue friendilyTone = new Dialogue("I won't harm you. I am Louis's friend. What is your name?", "You really .... Louis' friends? Then ... what was his ... occupation?", true);
        Dialogue directAnswer = new Dialogue("Firefighter!", "Cor ... rect I am Anna.. belle", true);
        Dialogue gainArtifact = new Dialogue("Hello, Annabelle. I'm here for artifact. We can escape from this woodland after having 8 artifacts. Can you give me yours? Louis gave me his too. Now, you have a chance to save Louis from here!", "I .. believe in ... Louis", "gain_artifact 4");
        Dialogue teaseAnna = new Dialogue("Why do you hide behind the shield? Such a funny person, ha, ha", "(Annabelle starts crying and doesn't give any response to the player)", "fail_game");
        Dialogue askName = new Dialogue("Can I know your name?", "Ann ... No", true);
        Dialogue hesitate = new Dialogue("What is his occupation? Wait, I need to think for a while. Fire... (player was interrupted by Annabelle)", "You lier! (Annabelle hides behind her shield and does not talk to the player again)", "fail_game");
        Dialogue thankYou = new Dialogue("Thank you!", "", true);

        start.Children = new Dialogue[] {friendilyTone, teaseAnna, askName};
        friendilyTone.Children = new Dialogue[] { directAnswer, hesitate };
        directAnswer.Children = new Dialogue[] {gainArtifact};
        gainArtifact.Children = new Dialogue[] {thankYou};
        askName.Children = new Dialogue[] {friendilyTone};
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
