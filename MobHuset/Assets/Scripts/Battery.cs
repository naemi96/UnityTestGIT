using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : InventoryItemBase  {
    public bool clicked = false;

    public override string Name {
        get 
        {
            return "Battery";
        }
    }

    public void changeClickState()
    {
        clicked = !clicked;
        //GetComponent<AudioSource>().Play();
    }

    


    public override void OnUse()
    {
        base.OnUse();
    }

}
