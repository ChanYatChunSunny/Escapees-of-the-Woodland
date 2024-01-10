using System.Text;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private TMP_Text dialogueText;
    [SerializeField]
    private GameObject escAbleText;
    public bool isInConversation;

    public DialogueGraph dialogueGraph { private get;  set; }

    // Start is called before the first frame update
    void Start()
    {
        isInConversation = false;
        escAbleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueGraph == null) { return; }
        if (dialogueGraph.CheckIsEnded()) 
        {
            dialogueUI.SetActive(false);
            return;
        }
        if (!isInConversation) { return; }
        dialogueUI.SetActive(true);
        if (dialogueGraph.IsLeaveable)
        {
            escAbleText.SetActive(true);
        }
        else
        {
            escAbleText.SetActive(false);
        }
        string[] options = dialogueGraph.GetCurrOptions();
        StringBuilder sb = new StringBuilder(dialogueGraph.GetCurrNpcSpeech());
        sb.Append("\n\n");
        for(int i = 0; i < options.Length; i++)
        {
            sb.Append(i);
            sb.Append(". ");
            sb.Append(options[i]);
            sb.Append("\n");
        }
        dialogueText.text = sb.ToString();
        int optionsLen = options.Length;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (dialogueGraph.IsLeaveable)
            {
                isInConversation = false;
                dialogueUI.SetActive(false);
            }
        }
        else if (isInConversation)
        {
            if (Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
            {
                if (optionsLen > 0)
                {
                    dialogueGraph.SelectNext(0);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
            {
                if (optionsLen > 1)
                {
                    dialogueGraph.SelectNext(1);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
            {
                if (optionsLen > 2)
                {
                    dialogueGraph.SelectNext(2);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
            {
                if (optionsLen > 3)
                {
                    dialogueGraph.SelectNext(3);
                }
            }
        }
    }

    


}
