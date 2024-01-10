using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public const int inventorySize = 8;
    public const float highlighterXPos = 10f;
    public const float highlighterChangePos = -31.25f;
    public const float highlighterInitYPos = 55f;
    public const float highlighterFinalYPos = -163.75f;
    private Aid[] inventory = new Aid[inventorySize];
    public Text[] inventoryValue = new Text[inventorySize];
    public int inverntoryCount = 0;
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] Text remainingHealth;
    public int maxHealth = 100;
    public int currentHealth;
    public float time = 0f;
    public HealthBarController healthBarController;
    private Rigidbody2D body;
    private Animator animator;
    public HighlighterController highlightController;
    // Start is called before the first frame update
    public void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBarController.SetMaxHealth(maxHealth);
        highlightController.SetPos(highlighterXPos, highlighterInitYPos, highlighterFinalYPos);
        Debug.Log("Player Spawn!");
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
        return inventory.Length <= inventorySize;
    }

    //function to add elements into inventory
    public void AddInventory(Aid element, int count)
    {
        if (CheckInventorySize())
        {
            inventory[count++] = element;
        }
        else
        {
            Debug.Log("Inventory is full");
        }
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
