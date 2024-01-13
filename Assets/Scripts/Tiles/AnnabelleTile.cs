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
        Dialogue start = new Dialogue("Hi", "Who are you... Stay away from me... I will only let Louis come close to me!", "(Annabelle hides herself behind a shield)", false);
        Dialogue friendilyTone = new Dialogue("I won't harm you. I am Louis's friend. What is your name?", "You really .... Louis' friends? Then ... what was his ... occupation?", false);
        Dialogue correctAnswer = new Dialogue("Firefighter!", "Cor ... rect I am Anna.. belle", false);
        Dialogue wrongAns0 = new Dialogue("Waterfighter!", "What are you talking about!?");
        Dialogue wrongAns1 = new Dialogue("Construction worker!", "Ahh! You are a lier! You are trying to hurt me! (Annabelle ran away with her shield)");
        Dialogue wrongAns2 = new Dialogue("Demolition worker!", "Ahh! You are a lier! You are trying to hurt me! (Annabelle ran away with her shield)");
        Dialogue aboutLouis = new Dialogue("Why you seems to be so afarid?", "I... Was a brave girl when I was young... But then there was a fire... Louis saved me.");
        Dialogue waa = new Dialogue("You are a scaredy cat? Waaa!", "AHHH!! (Annabelle ran away with her shield)");
        Dialogue gainArtifact = new Dialogue("Okay, Annabelle. I know you are scared about this place. I'm here for artifact so we can escape from here. Can you give me yours? Louis gave me his too.", "Okay... I... believe in Louis", "gain_artifact 3");
        Dialogue teaseAnna = new Dialogue("Why are so nervous? Such a funny person, ha, ha", "(Annabelle starts crying and doesn't give any response to the player)");
        Dialogue askName = new Dialogue("Can I know your name?", "Ann ... No", false);
        Dialogue guessName = new Dialogue("Let me make a guess. Are you Anna?", "No ...", false);
        Dialogue correctGuess = new Dialogue("Are you Annabelle?", "How do ... you ... know that? (Annabelle put her head up to the top of the shield)", false);
        Dialogue wrongGuess = new Dialogue("Are you Annaelle?", "No, no .... (player continue to make guess for more than ten times and still failed to guess the NPC's  name)", false);
        Dialogue lucky = new Dialogue("Lucky. I won't harm you, Annabelle. Do you want to leave this place and go back to your normal life?", "Yes! How ... can ... I go ...back...home?", false);
        Dialogue explain = new Dialogue("If we get all eight artifacts, we can escape from this woodland. One of the artifacts is at your side.", "Okay ... I will .... give it ... to you ... friendly guy", "gain_artifact 3");
        Dialogue thankYouFriendly = new Dialogue("Thank you Annabelle!", "", "leave_dialogue");
        Dialogue thankYou = new Dialogue("Thank you!", "", "leave_dialogue", true);
        Dialogue noPatient = new Dialogue("Stop wasting our time! Give me the thing you are holding then we are over!", "HELP! Someone is trying to hurt me! (Annabelle ran away with her shield)");
        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");


        start.Children = new Dialogue[] {friendilyTone, teaseAnna, askName};
        friendilyTone.Children = new Dialogue[] { wrongAns0, wrongAns1, correctAnswer, wrongAns2 };
        correctAnswer.Children = new Dialogue[] { aboutLouis };
        aboutLouis.Children = new Dialogue[] { waa, gainArtifact };
        gainArtifact.Children = new Dialogue[] {thankYou};
        askName.Children = new Dialogue[] { noPatient, guessName};
        guessName.Children = new Dialogue[] {wrongGuess, correctGuess};
        correctGuess.Children = new Dialogue[] {lucky};
        lucky.Children = new Dialogue[] {explain};
        explain.Children = new Dialogue[] {thankYouFriendly};
        wrongGuess.Children = new Dialogue[] { noooo };

        teaseAnna.Children = new Dialogue[] { noooo };
        wrongAns0.Children = new Dialogue[] { thankYou };
        wrongAns1.Children = new Dialogue[] { noooo };
        wrongAns2.Children = new Dialogue[] { noooo };
        noPatient.Children = new Dialogue[] { noooo };
        waa.Children = new Dialogue[] { noooo };
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
