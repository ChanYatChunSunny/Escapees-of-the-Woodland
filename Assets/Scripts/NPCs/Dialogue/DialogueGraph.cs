using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGraph
{
    private Dialogue curr;
    private bool isLeaveable;
    public DialogueGraph(Dialogue start)
    {
        curr = start;
    }

    public string[] GetCurrOptions()
    {
        Dialogue[] currChildren = curr.GetChildren();
        int currChildrenLen = currChildren.Length;
        string[] ret = new string[currChildrenLen];
        for(int i = 0; i < currChildrenLen; i++)
        {
            ret[i] = currChildren[i].GetTitle();
        }
        return ret;
    }
    
    public string GetCurrTitle()
    {
        return curr.GetTitle();
    }

    public string GetCurrRespond()
    {
        return curr.GetRespond();
    }

    public void SelectNext(int index)
    {
        curr = curr.GetChild(index);
        if (curr.IsLeaveable() != null)
        {
            isLeaveable = (bool)curr.IsLeaveable();
        }
    }

    public bool IsLeaveable()
    {
        return isLeaveable;
    }

    public bool IsEnded()
    {
        return curr.GetChildren().Length == 0;
    }

}
