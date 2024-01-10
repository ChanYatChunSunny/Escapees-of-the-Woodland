using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public const int inventorySize = 8;
    public const int ArtifactsNum = 8;
    public const float highlighterXPos = 10f;
    public const float highlighterChangePos = -31.25f;
    public const float highlighterInitYPos = 55f;
    public const float highlighterFinalYPos = -163.75f;
    private Aid[] inventory = new Aid[inventorySize];
    public TMP_Text[] inventoryValue = new TMP_Text[inventorySize];
    public int inverntoryCount = 0;
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] TMP_Text remainingHealth;
    [SerializeField] private TMP_Text actionText;
    public int maxHealth = 100;
    public int currentHealth;
    public float time = 0f;
    public HealthBarController healthBarController;
    private Rigidbody2D body;
    private Animator animator;
    public HighlighterController highlightController;
    private GameObject currTile;
    public DialogueHandler DialogueHandler { get; private set; }
    public bool[] carryingArtifacts = new bool[ArtifactsNum];

    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        DialogueHandler = GetComponent<DialogueHandler>();
        currentHealth = maxHealth;
        healthBarController.SetMaxHealth(maxHealth);
        highlightController.SetPos(highlighterXPos, highlighterInitYPos, highlighterFinalYPos);
        for(int i = 0; i < 8; i++)
        {
            carryingArtifacts[i] = false;
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        PrintFromInventory();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontal * movingSpeed * Time.deltaTime, vertical * movingSpeed * Time.deltaTime);

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
        
        
        
        ModifyHealth(-1);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            highlightController.ModifyPos(highlighterChangePos);
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
        
        
        ModifyHealth(-1);
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

    //function to get the element in inventory
    public void PrintFromInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i] != null)
            {
                inventoryValue[i].text = inventory[i].GetName();
            }
            else
            {
                inventoryValue[i].text = "- Empty " + i.ToString();
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
                inventory[inverntoryCount] = element;
                inventoryValue[inverntoryCount++].text = element.GetName();
                added = true;
                break;
            }
        }
        if(!added)
        {
            Debug.Log("Inventory is full");
        }
    }
    public void SetActionText(string str)
    {
        actionText.text = str;
    }
    public void FlashActionText()
    {
        actionText.gameObject.SetActive(true);
        StartCoroutine(DeactiveActionText());
    }
    private IEnumerator DeactiveActionText()
    {
        yield return new WaitForSeconds(1);
        actionText.gameObject.SetActive(false);
    }

    //function to consume the aids
    public void ConsumeAid()
    {
        int pos = highlightController.GetCount();
        if (inventory[pos] == null) { return; }
        inventory[pos].ConsumeBy(this);
        inventory[pos] = null;
        inventoryValue[pos].text = "-Empty ";
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
        }
    }
}
