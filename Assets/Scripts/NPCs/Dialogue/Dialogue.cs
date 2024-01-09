public class Dialogue
{
    private Dialogue[] children;
    private string title;
    private string respond;
    private string meta;
    private bool? isLeaveable;


    public Dialogue(Dialogue[] children, string title, string respond, string meta, bool? isLeaveable)
    {
        this.children = children;
        this.title = title;
        this.respond = respond;
        this.meta = meta;
        this.isLeaveable = isLeaveable;
    }
    public Dialogue(string title, string respond, string meta) : this(new Dialogue[0], title, respond, meta, null) { }

    public Dialogue(string title, string respond) : this(title, respond, "") { }

    public Dialogue(string title, string respond, bool? isLeaveable) : this(new Dialogue[0], title, respond, "", isLeaveable) { }

    public Dialogue[] Children
    {
        get { return children; }
        set { children = value; }
    }

    public string Meta
    {
        get { return meta; }
    }

    public string Respond
    {
        get { return respond; }
    }

    public string Title
    {
        get { return title; }
    }

    public bool? IsLeaveable
    {
        get { return isLeaveable; }
    }
}

