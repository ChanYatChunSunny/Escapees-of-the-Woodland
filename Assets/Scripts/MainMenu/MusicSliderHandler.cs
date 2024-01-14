using UnityEngine;
using UnityEngine.UI;

public class MusicSliderHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource musicSource;

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnValueChanged()
    {
        float val = slider.value; 
        musicSource.volume = val;
        Settings.MusicVol = val;
    }
}
