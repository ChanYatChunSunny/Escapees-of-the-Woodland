using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylaTile : Tile
{

    [SerializeField]
    private GameObject skyla;
    private DialogueGraph dialogueGraph;

    // Start is called before the first frame update
    public override void Start()
    {
        Instantiate(skyla, this.transform.position + new Vector3(-0.2f, 0, 1), Quaternion.identity);

        Dialogue start = new Dialogue("Hi? I need to...",
            "I love this place! I finally got a home of my own and don't have to worry about getting evicted!", true);

        Dialogue commentTent = new Dialogue("Your tent does look nice, you did this all by yourself?",
            "Oh, you are there. Hi, I am Skyla. No, a guy named Paul helped me with it, he is such a nice person.", false);
        Dialogue introduce = new Dialogue("Hi? What is your name? I need your help.",
            "My name is Skyla, and I am no longer homeless with this lovely home here, so I guess maybe I can help you.", false);
        Dialogue grossTent = new Dialogue("This is just a dirty campsite. Come on, I have something that I need you to cooperate with!",
            "This is not just a campsite! This is my home now!", false);
        start.Children = new Dialogue[] { commentTent, introduce, grossTent };

        Dialogue knowPaulToo = new Dialogue("You know Paul too? Great, we all need your help to escape this place!",
            "Why would I leave this place?... I will be homeless again back in the city...");
        commentTent.Children = new Dialogue[] { knowPaulToo };

        Dialogue usePaul = new Dialogue("Paul would like to return to his normal life as well, you don't want a person that helped you so much to get trapped here forever, right?",
            "Well... I suppose you are right... But...");
        Dialogue onlyKnewName = new Dialogue("You are Skyla, right? Now, I know you may like your tent, but there are many others here that want to escape, can you help me so we can leave here together?",
            "No! I won't leave this place! I really don't want to go back to the city!");
        knowPaulToo.Children = new Dialogue[] { usePaul, onlyKnewName };
        introduce.Children = new Dialogue[] { onlyKnewName };

        Dialogue plzAfterPaul = new Dialogue("Please, Paul and I can help you to find a housing option after we returned to the city. It may not be something great, but you would have a home.",
            "Fine, I guess you want this thing? You had been looking at it the whole time. Hope this can help him leave this place.", "gain_artifact 1");
        usePaul.Children = new Dialogue[] { plzAfterPaul };
        Dialogue thank = new Dialogue("Thank you so much for your help!",
            "you are welcome, oh yea, please tell Paul I really appreciate his help before", true);
        plzAfterPaul.Children = new Dialogue[] { thank };
        Dialogue canAfterwards = new Dialogue("You can tell him yourself after we escaped", "", "leave_dialogue", true);
        thank.Children = new Dialogue[] { canAfterwards };

        Dialogue promise = new Dialogue("I can help you look for a housing option after we returned to the city.", "I won't be able to afford it even if you found me a housing option.");
        onlyKnewName.Children = new Dialogue[] { grossTent, promise };
        Dialogue cantFeedHerForever = new Dialogue("I can't feed you forever! That is the best I can do! You should work hard yourself", "You think I hadn't tried? I hate people like you who think you are always right. Good bye, I am not helping you!");
        Dialogue helpFindWork = new Dialogue("I can help you find a job, I know some friends that are in need of employees like you.", "Really? Even a woman like me?... I don't believe you.");

        Dialogue destroyTent = new Dialogue("Enough! Just pick up your tent and leave this awful place! (Forcibly destroy her tent)", "What are you doing!? Now I lost my home because of you! (Entered a physical fight with the player)");
        grossTent.Children = new Dialogue[] { destroyTent };
        promise.Children = new Dialogue[] { cantFeedHerForever, helpFindWork, destroyTent };
        
        Dialogue nooo = new Dialogue("Nooo!", "", "fail_game");
        Dialogue nooooByHit = new Dialogue("Noooo!", "", "fail_game_injury");
        destroyTent.Children = new Dialogue[] { nooooByHit };
        cantFeedHerForever.Children = new Dialogue[] { nooo };

        Dialogue yesTheyReallyHire = new Dialogue("Yes, they really will hire people like you. Trust me. Now, give me the thing at your back so we can get out of here", "Let me think for a moment first...");
        helpFindWork.Children = new Dialogue[] { yesTheyReallyHire, destroyTent };

        Dialogue takeYourTime = new Dialogue("Alright, take your time.", "Fine, you can have the artifact. Remember your promise when we get out of here.", "gain_artifact 1");
        yesTheyReallyHire.Children = new Dialogue[] { takeYourTime, destroyTent };
        takeYourTime.Children = new Dialogue[] { thank };
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
