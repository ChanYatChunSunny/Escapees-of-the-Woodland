using TMPro;
using UnityEngine;

public abstract class Aid : MonoBehaviour
{
    [SerializeField]
    public TMP_Text actionText;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract string GetName();
    public abstract void ConsumeBy(PlayerController playerController);


}
