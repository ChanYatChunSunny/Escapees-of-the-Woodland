using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private TMP_Text dialogueText;

    public DialogueGraph DialogueGraph { private get;  set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueGraph == null || DialogueGraph.IsEnded()) 
        {
            dialogueUI.SetActive(false);
            return;
        }
        dialogueUI.SetActive(true);
        string[] options = DialogueGraph.GetCurrOptions();
        StringBuilder sb = new StringBuilder(DialogueGraph.GetCurrNpcSpeech());
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
        if(Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
        {
            if(optionsLen > 0)
            {
                DialogueGraph.SelectNext(0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            if (optionsLen > 1)
            {
                DialogueGraph.SelectNext(1);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            if (optionsLen > 2)
            {
                DialogueGraph.SelectNext(2);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            if (optionsLen > 3)
            {
                DialogueGraph.SelectNext(3);
            }
        }
    }

    


}
