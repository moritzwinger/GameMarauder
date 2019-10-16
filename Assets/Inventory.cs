using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory = new GameObject();
    public Image InventoryImage;

    // pick up item
    public void AddItem(GameObject item)
    {
        // pick up
        if (inventory == null)
        {
            // inventory = item;
            //update UI (Inventory)
            //InventoryImage.sprite = item.GetComponent<SpriteRenderer>().sprite;      
            UpdateInventoryItem(item);
            item.SendMessage("DoInteraction");
        } 
        // inventory  full
        else
        {
            // drop current item and replace
            DropItem();
            UpdateInventoryItem(item);
            item.SendMessage("DoInteraction");
        }
    }
    // drop item: for now, the item will respawn in its original place
    public void DropItem()
    {
        inventory.SetActive(true);
        inventory = null;
        InventoryImage.sprite = null;
    }

    // this returns the name of the current item in the inventory
    public string GetInventoryItemName()
    {
        return inventory.name;
    }

    // update Item in inventory: replace sprite and name (eg: filling a bucket)
    public void UpdateInventoryItem(GameObject replacementItem)
    {
        //Debug.Log(replacementItem.title);
        inventory = replacementItem;
        InventoryImage.sprite = replacementItem.GetComponent<SpriteRenderer>().sprite;
 
    }

}
