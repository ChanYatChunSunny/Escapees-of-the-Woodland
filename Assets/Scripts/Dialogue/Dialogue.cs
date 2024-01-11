public class Dialogue
{
    private Dialogue[] children;
    private string playerSpeech;
    private string npcSpeech;
    private string meta;
    private bool? isLeaveable;


    public Dialogue(Dialogue[] children, string playerSpeech, string npcSpeech, string meta, bool? isLeaveable)
    {
        this.children = children;
        this.playerSpeech = playerSpeech;
        this.npcSpeech = npcSpeech;
        this.meta = meta;
        this.isLeaveable = isLeaveable;
    }
    public Dialogue(string playerSpeech, string npcSpeech, string meta) : this(new Dialogue[0], playerSpeech, npcSpeech, meta, null) { }

    public Dialogue(string playerSpeech, string npcSpeech, string meta, bool? isLeaveable) : this(new Dialogue[0], playerSpeech, npcSpeech, meta, isLeaveable) { }

    public Dialogue(string playerSpeech, string npcSpeech) : this(playerSpeech, npcSpeech, "") { }

    public Dialogue(string playerSpeech, string npcSpeech, bool? isLeaveable) : this(new Dialogue[0], playerSpeech, npcSpeech, "", isLeaveable) { }

    public Dialogue[] Children
    {
        get { return children; }
        set { children = value; }
    }

    public string Meta
    {
        get { return meta; }
    }

    public string PlayerSpeech
    {
        get { return playerSpeech; }
    }

    public string NpcSpeech
    {
        get { return npcSpeech; }
    }

    public bool? IsLeaveable
    {
        get { return isLeaveable; }
    }
}

