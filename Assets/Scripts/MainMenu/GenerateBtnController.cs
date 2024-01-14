using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateBtnController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text wrongInputText;
    [SerializeField]
    private TMP_InputField seedField;
    [SerializeField]
    private TMP_InputField mapSizeField;

    // Start is called before the first frame update
    void Start()
    {
        seedField.text = "" + new Randomizer().GetInt(100000, 999999);
        mapSizeField.text = "32";
        wrongInputText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        wrongInputText.gameObject.SetActive(false);
        try
        {
            int seed = int.Parse(seedField.text);
            int mapSize = int.Parse(mapSizeField.text);
            if (seed > 0 && mapSize >= 16) 
            {
                Settings.GetRandomizer().SetSeed(seed);
                Settings.MapSize = mapSize;
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                wrongInputText.gameObject.SetActive(true);
            }
        }
        catch (Exception) 
        {
            wrongInputText.gameObject.SetActive(true);
        }

    }

}
