using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int inventorySize = 8;
    public const int ArtifactsNum = 7;
    private Aid[] inventory = new Aid[inventorySize];
    public TMP_Text[] inventoryValue = new TMP_Text[inventorySize];
    public int inverntoryCount = 0;
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] TMP_Text remainingHealth;
    [SerializeField] private TMP_Text actionText;
    [SerializeField] private GameObject starveUI;
    [SerializeField] private AudioSource musicSource;
    private int maxHealth = 100;
    private int currentHealth;
    public float time = 0f;
    public HealthBarController healthBarController;
    private Rigidbody2D body;
    private Animator animator;
    public HighlighterController highlightController;
    private GameObject currTile;
    public DialogueHandler DialogueHandler { get; private set; }
    public bool[] carryingArtifacts = new bool[ArtifactsNum];
    public bool playing;
    private Vector2 lastPos;
    private float healthToBeDeducted;

    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        DialogueHandler = GetComponent<DialogueHandler>();
        currentHealth = maxHealth;
        healthBarController.SetMaxHealth(maxHealth);
        highlightController.SetPos();
        for(int i = 0; i < 8; i++)
        {
            carryingArtifacts[i] = false;
        }
        playing = true;
        lastPos = body.position;
        healthToBeDeducted = 0.0f;
        starveUI.SetActive(false);
        musicSource.volume = Settings.MusicVol;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (!playing) {
            body.velocity = Vector2.zero;
            animator.SetBool("walking", false);
            return;
        }
        UpdateInventory();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(horizontal, vertical);
        Animate(horizontal, vertical);
    }


    
    /// <summary>
    /// Update is more suitable for key detection while fixed update is more suitable for movement calculation
    /// </summary>
    public void Update()
    {
        if (!playing) { return; }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            highlightController.ModifyPos();
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            if(currTile != null)
            {
                currTile.GetComponent<Tile>().Interact(this);
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            ConsumeAid();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            currTile = collision.gameObject;
        }
        else if (collision.CompareTag("Aid") && collision.gameObject.activeInHierarchy)
        {
            AddInventory(collision.GetComponent<Aid>());
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.Equals(currTile))
        {
            currTile = null;
        }
    }

    /// <summary>
    /// Move the player then decrease health based on how much the player had moved
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    private void Move(float horizontal, float vertical)
    {
        Vector2 newVelocity = new Vector2(horizontal * movingSpeed * Time.deltaTime, vertical * movingSpeed * Time.deltaTime);
        body.velocity = newVelocity;
        healthToBeDeducted += ((lastPos - body.position).magnitude) / 2.8f;
        int healthDeductingNow = (int)healthToBeDeducted;
        ModifyHealth(-healthDeductingNow);
        healthToBeDeducted -= healthDeductingNow;
        lastPos = body.position;
    }
    private void Animate(float horizontal, float vertical)
    {
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            if (horizontal > 0.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (horizontal < -0.0f)
            {
                transform.localScale = Vector3.one;
            }
            animator.SetBool("walking", true);
            animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    //function to get the element in inventory
    private void UpdateInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i] != null)
            {
                inventoryValue[i].text = inventory[i].GetName();
            }
            else
            {
                inventoryValue[i].text = "Empty ";
            }
        }
    }

    //function to check whether the inventory is full or not
    public bool CheckInventorySize()
    {
        return inventory.Length < inventorySize;
    }

    //function to add elements into inventory
    public void AddInventory(Aid element)
    {
        bool added = false;
        for(int i = 0; i < inventorySize; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = element;
                added = true;
                break;
            }
        }
        if(!added)
        {
            ShowActionText("Inventory is full");
        }
    }
    /// <summary>
    /// Show an action text and hide it 2 secs later
    /// </summary>
    /// <param name="str">the string to be displayed on the action text</param>
    public void ShowActionText(string str)
    {
        actionText.text = str;
        actionText.gameObject.SetActive(true);
        StartCoroutine(DeactiveActionText());
    }
    private IEnumerator DeactiveActionText()
    {
        yield return new WaitForSeconds(2);
        actionText.gameObject.SetActive(false);
    }

    //function to consume the aids
    public void ConsumeAid()
    {
        int pos = highlightController.GetCount();
        if (inventory[pos] == null) { return; }
        inventory[pos].ConsumeBy(this);
        inventory[pos] = null;
    }

    //function to change the health of player
    public void ModifyHealth(int num)
    {
        currentHealth += num;
        healthBarController.SetHealth(currentHealth);
        remainingHealth.text = "HP: " + currentHealth.ToString();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthBarController.SetHealth(currentHealth);
            remainingHealth.text = "HP: " + currentHealth.ToString();
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
            healthBarController.SetHealth(currentHealth);
            remainingHealth.text = "HP: " + currentHealth.ToString();
            playing = false;
            starveUI.SetActive(true);
        }
    }
}
