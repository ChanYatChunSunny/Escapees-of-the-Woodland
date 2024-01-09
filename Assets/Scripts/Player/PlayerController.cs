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
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Player Spawn!");
    }

    // Update is called once per frame
    public void Update()
    {
        PrintFromInventory();
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, movingSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(0, -movingSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(movingSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(-movingSpeed * Time.deltaTime, 0, 0);
        }
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
