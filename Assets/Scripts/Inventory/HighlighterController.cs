using UnityEngine;

public class HighlighterController : MonoBehaviour
{
    [SerializeField] private float initXPos = 7.7442f;
    [SerializeField] private float initYPos = 55f;
    [SerializeField] private float offset = -31.25f;
    [SerializeField] private float finalYPos = -163.75f;
    private float currentYPos;
    private int count = 0;

    //function to set the position of the highlighter
    public void SetPos()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initXPos, initYPos);
        currentYPos = initYPos;
    }

    //function to adjust the position of the highlighter
    public void ModifyPos() 
    { 
        currentYPos += offset;
        //Debug.Log(currentPosY.ToString());
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initXPos, currentYPos);
        count++;
        if (currentYPos < finalYPos) 
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(initXPos, initYPos);
            currentYPos = initYPos;
            count = 0;
        }
    }

    //function to return the current element the highlighter is at
    public int GetCount()
    {
        return count;
    }
}
