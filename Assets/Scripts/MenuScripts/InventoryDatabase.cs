/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDatabase : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    private void Awake()
    {
        CreateDatabase();
    }

    public InventoryItem GetItem(int id)
    {
        return items.Find(item => item.ID == id);
    }

    public InventoryItem GetItem(string name)
    {
        return items.Find(item => item.Name == name);
    }
    void CreateDatabase()
    {
        items = new List<InventoryItem>()
        {
            new InventoryItem(0, "item", "an object being tested."),

            new InventoryItem(1, "item", "an object being tested again."),

            new InventoryItem(2, "item", "last object!")
        };
    }
}
*/
