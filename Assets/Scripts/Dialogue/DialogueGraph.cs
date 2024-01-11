
using UnityEngine;

public class DialogueGraph
{
    private Dialogue curr;
    public bool IsLeaveable { get; private set; }
    public DialogueGraph(Dialogue start)
    {
        curr = start;
    }

    public string[] GetCurrOptions()
    {
        Dialogue[] currChildren = curr.Children;
        int currChildrenLen = currChildren.Length;
        string[] ret = new string[currChildrenLen];
        for(int i = 0; i < currChildrenLen; i++)
        {
            ret[i] = currChildren[i].PlayerSpeech;
        }
        return ret;
    }
    
    public string GetCurrNpcSpeech()
    {
        return curr.NpcSpeech;
    }

    public string GetCurrPlayerSpeech()
    {
        return curr.PlayerSpeech;
    }

    public string GetCurrMeta()
    {
        return curr.Meta;
    }

    public void SelectNext(int index)
    {
        Debug.Log(index);
        curr = curr.Children[index];
        IsLeaveable = curr.IsLeaveable==true;
    }


    public bool CheckIsEnded()
    {
        return curr.Children.Length == 0;
    }

}
