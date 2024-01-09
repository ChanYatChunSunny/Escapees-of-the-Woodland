using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int inventorySize = 10;
    private string[] inventory = new string[inventorySize];
    public int inverntoryCount = 0;
    public int health = 100;
    [SerializeField] float movingSpeed = 5f;

    private Rigidbody2D body;

    // Start is called before the first frame update
    public void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        Debug.Log("Player Spawn!");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        PrintFromInventory();
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movingSpeed * Time.deltaTime);
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
}
