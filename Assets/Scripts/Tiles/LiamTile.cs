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

        Dialogue start = new Dialogue("Hi...?", "Hi. I am Liam, I am a simiiforme haplorhini primate known as homo sapien. I am studying science in an institution known as a university.", false);

        Dialogue nerd = new Dialogue("What a nerd.", "Conversation is terminated forever! Leave now!");


        Dialogue alreadyGotSome = new Dialogue("Hi, Liam. We need a few artifacts to escape here! I had already got some, but I need yours as well.", "So... Lucy gave you her artifact as well?");
        Dialogue yesLucy = new Dialogue("Yes, Lucy did give me her artifact.", "Then you are one of that horse religion? I am not going to listen to you.");
        Dialogue believer = new Dialogue("Starflame is our only guidance, stop hiding the truth", "Get out! I don't want to hear speech from your kind of homo sapiens ever again!");
        Dialogue yesBut = new Dialogue("Yes, she does. But I don't really believe in whatever she is beliving, and I need your help!", "Justify the reasoning for your request then.");
        yesLucy.Children = new Dialogue[] { believer, yesBut };

        Dialogue noLucy = new Dialogue("No, I didn't. But I really need your help.", "Justify the reasoning for your request then.");
        alreadyGotSome.Children = new Dialogue[] { yesLucy, noLucy };

        Dialogue whatIHeard = new Dialogue("According to what I heard before I was fainted, some people had kidnapped us here for some sick experiment. I need your artifact to end it.", "I strongly condemn unethical experiment. But there is a 50% chance that you are lying to me.");
        Dialogue plzTrust = new Dialogue("There is no benefit for me to lie to you.", "Prehaps this artifact is an expensive material. There is still a 25% chance you are lying to me.");
        whatIHeard.Children = new Dialogue[] { nerd, plzTrust };
        Dialogue mustGetOut = new Dialogue("We are trapped in here together, any profit I get from you is useless unless we are out.", "12.5% chance. After careful analysis, I accept the risk, here you go.", "gain_artifact 6");
        plzTrust.Children = new Dialogue[] { mustGetOut, nerd };
        Dialogue thank = new Dialogue("Thank you. We should be able to get out soon then you can continue your research.", "Nice.", "leave_dialogue", true);
        mustGetOut.Children = new Dialogue[] { nerd, thank };

        Dialogue explainSituation = new Dialogue("Hello world. if you give me the artifact then we can escape else we do will be trapped in here while true.", "A programmer huh? I learned a bit of C# for my simulation project as well. Anyway, do you have any evidence?");
        noLucy.Children = new Dialogue[] { whatIHeard, explainSituation};
        yesBut.Children = new Dialogue[] { whatIHeard, explainSituation };
        Dialogue programmer = new Dialogue("I don't have any physical evidence, but I did heard our kidnapper mention it before I fainted.", "Well, because you are a programmer, I assume you would not make a false statement... Okay, here you go.", "gain_artifact 6");
        explainSituation.Children = new Dialogue[] { programmer };
        Dialogue ack = new Dialogue("Acknowledged. Thank you.", "You are welcome. You guys helped me a lot in my projects.", "leave_dialogue", true);
        programmer.Children = new Dialogue[] { ack };

        Dialogue noScience = new Dialogue("I don't believe in science", "Great, yet another homo sapien like Lucy waiting to be removed from the genetic pool.");
        start.Children = new Dialogue[] { alreadyGotSome, explainSituation, noScience };

        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");
        nerd.Children = new Dialogue[] { noooo };
        believer.Children = new Dialogue[] { believer };
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
