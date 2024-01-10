using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : Tile
{
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject successUI;
    // Start is called before the first frame update
    public override void Start()
    {
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
    }
}
