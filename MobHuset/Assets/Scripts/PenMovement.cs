using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenMovement : MonoBehaviour
{

    public Ray ray;
    public RaycastHit hit;
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }
    /*
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           ray = new Ray(transform.position, transform.forward);
            
            if(Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.CompareTag("Pen"))
                {   
                    print ("Penna");
                    anim.SetTrigger("Active");
                }
            }
        }
    }
    */
}
