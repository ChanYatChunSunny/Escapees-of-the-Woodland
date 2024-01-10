using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HighlighterController : MonoBehaviour
{
    public float initPosX;
    public float initPosY;
    public float finalPosY;
    public float currentPosY;
    public int count = 0;

    //function to set the position of the highlighter
    public void SetPos(float initPosX, float initPosY, float finalPosY)
    {
        this.initPosX = initPosX;
        this.initPosY = initPosY;
        this.finalPosY = finalPosY;
        currentPosY = initPosY;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, initPosY);
    }

    //function to adjust the position of the highlighter
    public void ModifyPos(float updatevalue) 
    { 
        currentPosY += updatevalue;
        //Debug.Log(currentPosY.ToString());
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, currentPosY);
        count++;
        if (currentPosY < finalPosY) 
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, initPosY);
            currentPosY = initPosY;
            count = 0;
        }
    }

    //function to return the current element the highlighter is at
    public int GetCount()
    {
        return count;
    }
}
