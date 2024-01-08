using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Data;
using System;
using UnityEngine.SceneManagement;

public class StartBtnController : MonoBehaviour
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
        wrongInputText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        wrongInputText.gameObject.SetActive(false);
        GameData.Init();
        try
        {
            int seed = int.Parse(seedField.text);
            int mapSize = int.Parse(mapSizeField.text);
            if (seed > 0 && mapSize > 32) 
            {
                GameData.GetRandomizer().SetSeed(seed);
                GameData.SetMapSize(mapSize);
                SceneManager.LoadScene("GameScene");
            }
        }
        catch (Exception) 
        {
        
        }

    }

}
