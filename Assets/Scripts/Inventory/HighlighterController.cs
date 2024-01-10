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
    public const float posZ = 0f;

    public void SetPos(float initPosX, float initPosY, float finalPosY)
    {
        this.initPosX = initPosX;
        this.initPosY = initPosY;
        this.finalPosY = finalPosY;
        currentPosY = initPosY;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, initPosY);
    }

    public void ModifyPos(float updatevalue) 
    { 
        currentPosY += updatevalue;
        Debug.Log(currentPosY.ToString());
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, currentPosY);
        if (currentPosY < finalPosY) 
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(initPosX, initPosY);
            currentPosY = initPosY;
        }
    }
}
