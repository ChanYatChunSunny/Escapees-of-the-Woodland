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

    [SerializeField]
    private GameObject failedUI;
    public bool isInConversation;

    public DialogueGraph dialogueGraph { private get;  set; }
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
        isInConversation = false;
        playerController = GetComponent<PlayerController>();
        dialogueUI.SetActive(false);
        escAbleText.SetActive(false);
        failedUI.SetActive(false);
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
                    SelectOption(0);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
            {
                if (optionsLen > 1)
                {
                    SelectOption(1);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
            {
                if (optionsLen > 2)
                {
                    SelectOption(2);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
            {
                if (optionsLen > 3)
                {
                    SelectOption(3);
                }
            }
        }
    }
    private void SelectOption(int option)
    {
        dialogueGraph.SelectNext(option);
        string meta = dialogueGraph.GetCurrMeta();
        HandleMeta(meta);
    }

    private void HandleMeta(string meta)
    {
        if (meta.StartsWith("gain_artifact"))
        {
            int artifactIndex = int.Parse(meta.Replace("gain_artifact ", ""));
            playerController.carryingArtifacts[artifactIndex] = true;
            playerController.SetActionText("You had gained an artifact. Return it to the pedestal!");
            playerController.FlashActionText();
        }else if (meta.Equals("leave_dialogue"))
        {
            isInConversation = false;
            dialogueUI.SetActive(false);
        }else if (meta.Equals("fail_game"))
        {
            playerController.playing = false;
            failedUI.SetActive(true);
        }
    }




}
