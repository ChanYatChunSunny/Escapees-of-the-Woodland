using UnityEngine;

public class StartBtnController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainObj;
    [SerializeField]
    private GameObject GenObj;

    // Start is called before the first frame update
    void Start()
    {
        Settings.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        mainObj.SetActive(false);
        GenObj.SetActive(true);

    }

}
