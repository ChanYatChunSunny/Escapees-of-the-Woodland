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

        Dialogue start = new Dialogue("Hello? I need your help.",
            "Hi. I am Lucy, are you the follower of Starflame, the horse deity?", true);

        Dialogue freeFood = new Dialogue("Hey free food! (Grab the carrots under the altar)",
            "NO! You can't take the holy carrots of Starflame! May the justice be served! (She repeatedly hit you with the bible under the the altar)", false);

        Dialogue alwaysWant = new Dialogue("I always want to learn more about Starflame, but we need to leave this place first, can you give me the artifact you are holding?",
            "No way, this is the gift of Starflame. I won't give it to anyone. I'll certainly get punished if I give it to you.", false);
        Dialogue iHaveToo = new Dialogue("I have this artifact too, and I know the truth of why we are stuck here. If Starflame don't trust me, they wouldn't have given me this as well.",
            "What, it is not possible. I thought it must be from Starflame...");


        Dialogue youFool = new Dialogue("No, it is not from Starflame, give it to me now. How could you believe that? You are so stupid.",
            "It has to be from Starflame! Get away from me! I am not going to talk with you anymore!");
        alwaysWant.Children = new Dialogue[] { iHaveToo, youFool };

        Dialogue lookAndTrustYou = new Dialogue("What I said is real, we need to get you out of here to spread the good of Starflame", "Alright, I will do it for Starflame.", "gain_artifact 5");
        iHaveToo.Children = new Dialogue[] { youFool, lookAndTrustYou };
        Dialogue thank = new Dialogue("Thank you. May Starflame be with us.", "May Starflame bless you.", "", true);
        lookAndTrustYou.Children = new Dialogue[] { thank };

        Dialogue noBelieve = new Dialogue("No, I don't believe in Starflame. I believe in science",
            "Another person like Liam, huh? Well, then let me explain why Starflame is the true and only deity.", false);
        Dialogue[] religiousTalks = new Dialogue[4];
        religiousTalks[0] = new Dialogue("...",
            "Scientists have long tried to explain the phenomenon of the Northern Lights but to no avail. It has to be Starflame galloping across the night sky, leaving behind their fiery hoofprints that shimmer and dance, creating the awe-inspiring display of the...");

        religiousTalks[1] = new Dialogue("...",
            "There are many springs that possess unique composition with extraordinary healing properties. These springs can only be the physical manifestations of Starflame's divine power...");

        religiousTalks[2] = new Dialogue("...",
            "Scientists attributed the change in seasons to the tilt of the Earth's axis. However, it is impossible because... It is actually Starflame racing across its holy race court that resulted in the endless loop of seasons. Without them, we would be in perpetual winter...");

        religiousTalks[3] = new Dialogue("...",
            "Breeze in the world is actually a result of Starflame as they run through the sky... Without them, the Earth would eventually become a windless oven that kill all living beings...");

        for (int i = 0; i < 3; i++)
        {
            religiousTalks[i].Children = new Dialogue[] { freeFood, religiousTalks[i + 1] };
        }
        noBelieve.Children = new Dialogue[] { freeFood, religiousTalks[0] };

        Dialogue conclusion = new Dialogue("But ain't you just said Winter...", "In conclusion, that is why Starflame is very real. So, do you believe in Starflame now?");
        religiousTalks[3].Children = new Dialogue[] { conclusion };

        Dialogue yesNow = new Dialogue("Yes! You conviced me! Starflame is the sole answer to all our questions! Now, I need your help, fellow believer", "What is it that I can help a new Starflame follower?");
        conclusion.Children = new Dialogue[] { noBelieve, yesNow };
        yesNow.Children = new Dialogue[] { alwaysWant };

        start.Children = new Dialogue[] {alwaysWant, noBelieve, freeFood};

        Dialogue noooo = new Dialogue("Noooo!", "", "fail_game");
        Dialogue nooooByHit = new Dialogue("Noooo!", "", "fail_game_injury");
        freeFood.Children = new Dialogue[] { nooooByHit };
        youFool.Children = new Dialogue[] { noooo };
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
