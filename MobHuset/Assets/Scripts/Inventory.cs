using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int SLOTS = 8;

    public List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public event EventHandler<InventoryEventArgs> ItemUsed;



    void Update ()

    {
        if (Input.GetKeyDown("1"))
        {
            if (mItems.Count == 0)
            {
                print ("There is no item in the no.1 slot.");
            }
            //else if the item is battery 
                //if battery collides with car 
                    //add battery to car
                //else if battery colleds with other
                    //error message
            //else if the item is NOT battery
                //do something else

            else 
            {
                print ("1 was pressed.");
                //make sprite disappear - removeItem function? how do I call it?
                //setActive battery in RC if player is in proximity to it
            }
        }
    }


    
    //ADD ITEM
    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item);

                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            
            }
        }
    }

    internal void UseItem(IInventoryItem item)
    {
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if(mItems.Contains(item))
        {
            mItems.Remove(item);
            //item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider != null)
            {
                collider.enabled = true;
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}

    