using UnityEngine;
using TMPro;
using System.Collections;

public class Apple : Aid
{
    public override void ConsumeBy(PlayerController playerController)
    {
        playerController.ModifyHealth(10);
        actionText.gameObject.SetActive(true);
        actionText.SetText("You ate an apple");
        StartCoroutine(DeactiveActionText());

    }
    private IEnumerator DeactiveActionText()
    {
        yield return new WaitForSeconds(1);
        actionText.gameObject.SetActive(false);
    }

    public override string GetName()
    {
        return "apple";
    }

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }



}
