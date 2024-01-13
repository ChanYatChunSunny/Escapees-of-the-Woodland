using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTile : Tile
{
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject successUI;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private Sprite[] pedestalSprites;

    private int submittedArtifactsNum;
    private bool[] submittedArtifacts;
    private SpriteRenderer spriteRenderer;
    private Stopwatch timer;
    // Start is called before the first frame update
    public override void Start()
    {
        submittedArtifactsNum = 0;
        submittedArtifacts = new bool[PlayerController.ArtifactsNum];
        for(int i = 0; i < PlayerController.ArtifactsNum; i++)
        {
            submittedArtifacts[i] = false;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = new Stopwatch();
        timer.Start();
        StartCoroutine(FadingStartUI());
    }
    private IEnumerator FadingStartUI()
    {
        float elapsedTime = 0f;
        CanvasGroup canvasGroup = startUI.GetComponent<CanvasGroup>();
        float orgAlpha = canvasGroup.alpha;

        while (elapsedTime < 8)
        {
            float newAlpha = Mathf.Lerp(orgAlpha, 0f, elapsedTime / 8);
            canvasGroup.alpha = newAlpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f; // Ensure the alpha is 0 at the end
    }

    // Update is called once per frame
    public override void Update()
    {

    }
    public override void Interact(PlayerController playerController)
    {
        for(int i = 0; i < PlayerController.ArtifactsNum; i++)
        {
            if (playerController.carryingArtifacts[i])
            {
                if (!submittedArtifacts[i])
                {
                    submittedArtifactsNum++;
                    spriteRenderer.sprite = pedestalSprites[submittedArtifactsNum];
                    playerController.carryingArtifacts[i] = false;
                    submittedArtifacts[i] = true;

                }
            }
        }
        if (submittedArtifactsNum >= PlayerController.ArtifactsNum) 
        {
            playerController.playing = false;
            timer.Stop();
            int min = (int)timer.ElapsedMilliseconds / 60000;//Int automatically round down
            int sec = (int)(timer.ElapsedMilliseconds - (min * 60000)) / 1000;
            timerText.text = "Time spent: "+min+":"+sec;
            successUI.SetActive(true);
        }
    }
}
