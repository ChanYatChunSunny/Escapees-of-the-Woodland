using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public const int inventorySize = 10;
    private string[] inventory = new string[inventorySize];
    public int inverntoryCount = 0;
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] Text remainingHealth;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarController healthBarController;
    private Rigidbody2D body;

    // Start is called before the first frame update
    public void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBarController.SetMaxHealth(maxHealth);
        Debug.Log("Player Spawn!");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        PrintFromInventory();
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movingSpeed * Time.deltaTime);
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        ModifyHealth(-1);
    }

    //function to get the element in inventory
    public void PrintFromInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            Debug.Log(inventory[i] + "\n");
        }
    }

    //function to check whether the inventory is full or not
    public bool CheckInventorySize()
    {
        return inventory.Length <= inventorySize;
    }

    //function to add elements into inventory
    public void AddInventory(string element, int count)
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
