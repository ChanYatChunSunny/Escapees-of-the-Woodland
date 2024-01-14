
using UnityEngine;

public class DialogueGraph
{
    private Dialogue curr;
    public bool IsLeaveable { get; private set; }
    public DialogueGraph(Dialogue start)
    {
        curr = start;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>An array of string representing the possible dialogue options of the player</returns>
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
    /// <summary>
    /// 
    /// </summary>
    /// <returns>What the NPC should be saying at this moment</returns>
    public string GetCurrNpcSpeech()
    {
        return curr.NpcSpeech;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>What the player is saying at this moment</returns>
    public string GetCurrPlayerSpeech()
    {
        return curr.PlayerSpeech;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>What the meta is at this moment</returns>
    public string GetCurrMeta()
    {
        return curr.Meta;
    }
    /// <summary>
    /// Pick the next dialogue (Player should do so after reading the options)
    /// </summary>
    /// <param name="index">The index of the next dialogue</param>
    public void SelectNext(int index)
    {
        curr = curr.Children[index];
        IsLeaveable = curr.IsLeaveable==true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Whether this dialogue graph had ended</returns>
    public bool CheckIsEnded()
    {
        return curr.Children.Length == 0;
    }

}
