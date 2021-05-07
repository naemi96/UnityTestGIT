using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InteractScript : MonoBehaviour {

    public float interactDistance = 3000f;
    
    public Inventory inventory;

    public Battery batRC1;
    public Battery batRC2;

    public Key key;
    public GameObject doorText;

    public GameObject bookText1;
    public GameObject bookText2;
    public GameObject bookText3;
    public GameObject bookText4;

    public GameObject battery;
    public GameObject blackBox;
    public GameObject battery1RC;
    public GameObject battery2RC;
    public GameObject batteryPickUpText;

    public GameObject TV;

    public RC rc;

    public GameObject yellowSocket;
    public GameObject redSocket;
    public GameObject blueSocket;
    public GameObject greenSocket;
    public GameObject navySocket;
    public GameObject sladd;

    public bool hasKey = false;

    public GameObject pen;
    public GameObject lineRend;
    public AudioSource sound;

    public bool[] socketStatus = new bool[] {false,false,false,false,false};

    public void socketStatusFalse()
    {
        socketStatus = new bool[] {false,false,false,false,false};
    }

    public void deactivateCordEffects()
    {
        if (Array.Exists(socketStatus, x => true))
            {
                int isActiveCord = Array.IndexOf(socketStatus, true);

            if (isActiveCord == 0)
            {
                sound = yellowSocket.GetComponent<AudioSource>();
                sound.Play();

                print("Gul effekt slutar :)");
            }
            else if (isActiveCord == 1)
            {
                laptopScreenRed.GetComponent<LaptopScreen>().ChangePlayState();
                laptopScreenRed.SetActive(false);
            }
            else if (isActiveCord == 2)
            {
                laptopScreenBlue.GetComponent<LaptopScreen>().ChangePlayState();
                laptopScreenBlue.SetActive(false);
            }
            else if (isActiveCord == 3)
                print("Grön effekt slutar :)");
            else
                print("Navy effekt slutar :)");
                    laptopScreenBlue.SetActive(true);
            }   
        else print("no active cords");
    }

    void deactivateCords()
    {
        yellowSocket.SetActive(false);
        redSocket.SetActive(false);
        blueSocket.SetActive(false);
        greenSocket.SetActive(false);
        navySocket.SetActive(false);
        sladd.SetActive(false);
        
    }

    public GameObject laptopScreenBlue;
    public GameObject laptopScreenRed;
    public GameObject laptopScreenNavy;

   // public GameObject FloatingText;

    public bool started;

    // CODE FOR LIBRARY LIGHTS
    /*
    public GameObject libraryLampTurnOn;
    public GameObject libraryLampTurnOn1;
    public GameObject libraryLampTurnOn2;
    public GameObject libraryLampMaterial;
    public GameObject libraryLampMaterial1;
    */

    //public Material lightOn;

    public Ray ray;
    public RaycastHit hit;

    void Start()
    {   
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
    }

    IEnumerator WaitForSecBatteryPickUp()
    {
        yield return new WaitForSeconds(3);
        batteryPickUpText.SetActive(false);
    }

    IEnumerator WaitForSecDoorText()
    {
        yield return new WaitForSeconds(3);
        doorText.SetActive(false);
    }

    IEnumerator WaitForSecBook()
    {
        if (!started)
        {
            started = true;
            yield return new WaitForSeconds(1);
            Vector3 newPosition = hit.transform.position;
            newPosition.x = newPosition.x -3;
            hit.transform.position = newPosition;
            started = false;
            
            if (hit.collider.CompareTag("Book1"))
            {
                bookText1.SetActive(false);
            }
            else if (hit.collider.CompareTag("Book2"))
            {
                bookText2.SetActive(false);
            }

            else if (hit.collider.CompareTag("Book3"))
            {
                bookText3.SetActive(false);
            }

            else if (hit.collider.CompareTag("Book4"))
            {
                bookText4.SetActive(false);
            }
        }
    }


    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Mouse0))
        {
           ray = new Ray(transform.position, transform.forward);
            
            if(Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.CompareTag("Door"))
                {
                    if (hasKey) {
                        hit.collider.transform.GetComponent<DoorScript>().ChangeDoorState();
                        inventory.RemoveItem(key);
                    }
                    else 
                    {
                        doorText.SetActive(true);
                        StartCoroutine("WaitForSecDoorText");
                    }
                    
                }

                else if (hit.collider.CompareTag("Pen"))
                {
                    pen.GetComponent<Animator>().SetTrigger("Active");
                    lineRend.SetActive(true);
                }

                else if(hit.collider.CompareTag("Key"))
                {
                    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
                    if (item != null)
                    {
                        inventory.AddItem(item);
                        hasKey = true;
                        print("key picked up!");
                    
                    }
                }

                else if(hit.collider.CompareTag("Selectable"))
                {
                    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();

                    if (item != null)
                    {
                        inventory.AddItem(item);
                        print("Item picked up!");

                    }
                }


                else if(hit.collider.CompareTag("RotateButton"))
                {
                    rc.ChangeRotateState();
                }

                else if(hit.collider.CompareTag("On/Off"))
                {
                    rc.ChangeBatteryState();
                }

                else if(hit.collider.CompareTag("GulSocket"))
                { 
                    print ("Nu trycker du på den gula.");
                    deactivateCords();
                    deactivateCordEffects();
                    socketStatusFalse();
                    socketStatus[0] = true;
                    yellowSocket.SetActive(true);
                }

                else if(hit.collider.CompareTag("RödSocket"))
                { 
                    print ("Nu trycker du på den röda.");
                    deactivateCords();
                    deactivateCordEffects();
                    socketStatusFalse();
                    socketStatus[1] = true;
                    redSocket.SetActive(true);
                    laptopScreenRed.SetActive(true);
                    laptopScreenRed.GetComponent<LaptopScreen>().ChangePlayState();
                }


                else if(hit.collider.CompareTag("BlåSocket"))
                { 
                    print ("Nu trycker du på den blåa.");
                    deactivateCords();
                    deactivateCordEffects();
                    socketStatusFalse();
                    socketStatus[2] = true;
                    blueSocket.SetActive(true);
                    laptopScreenBlue.SetActive(true);
                    laptopScreenBlue.GetComponent<LaptopScreen>().ChangePlayState();
                }

                else if(hit.collider.CompareTag("GrönSocket"))
                { 
                    print("Nu trycker du på den gula.");
                    deactivateCords();
                    deactivateCordEffects();
                    socketStatusFalse();
                    socketStatus[3] = true;
                    greenSocket.SetActive(true);
                }

                else if(hit.collider.CompareTag("NavySocket"))
                { 
                    print ("Nu trycker du på den gula.");
                    deactivateCords();
                    deactivateCordEffects();
                    socketStatusFalse();
                    socketStatus[4] = true;
                    navySocket.SetActive(true);
                }


                else if(hit.collider.CompareTag("Battery"))
                {
                    //hit.collider.transform.GetComponent<Battery>().changeClickState();
                    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
                    if (item != null)
                    {
                        inventory.AddItem(item);
                        batteryPickUpText.SetActive(true);
                        StartCoroutine("WaitForSecBatteryPickUp");
                        
                        TV.GetComponent<TV>().ChangePlayState();

                     //   FloatingText.SetActive(true);
                      //  FloatingText.GetComponent<ClueText>().ChangePlayState();
                       // StartCoroutine("WaitForSec");
                    }
                }
                else if (hit.collider.CompareTag("Button"))
                {
                    hit.collider.transform.GetComponent<RedButton>().ChangeClickState();
                }

                else if (hit.collider.CompareTag("Button2"))
                {
                    hit.collider.transform.GetComponent<RedButton2>().ChangeClickState();
                }

                else if(hit.collider.CompareTag("Book1"))
                {
                    if(hit.transform != null)
                    {
                        Vector3 newPosition = hit.transform.position;
                        newPosition.x = newPosition.x +3;
                        hit.transform.position = newPosition;
                        bookText1.SetActive(true);
                        StartCoroutine("WaitForSecBook");
                    }
                }
                else if(hit.collider.CompareTag("Book2"))
                {
                    if(hit.transform != null)
                    {
                        Vector3 newPosition = hit.transform.position;
                        newPosition.x = newPosition.x +3;
                        hit.transform.position = newPosition;
                        bookText2.SetActive(true);
                        StartCoroutine("WaitForSecBook");
                    }
                }

                else if(hit.collider.CompareTag("Book3"))
                {
                    if(hit.transform != null)
                    {
                        Vector3 newPosition = hit.transform.position;
                        newPosition.x = newPosition.x +3;
                        hit.transform.position = newPosition;
                        bookText3.SetActive(true);
                        StartCoroutine("WaitForSecBook");
                    }
                }

                else if(hit.collider.CompareTag("Book4"))
                {
                    if(hit.transform != null)
                    {
                        Vector3 newPosition = hit.transform.position;
                        newPosition.x = newPosition.x +3;
                        hit.transform.position = newPosition;
                        bookText4.SetActive(true);
                        StartCoroutine("WaitForSecBook");
                    }
                }

                else if(hit.collider.CompareTag("BlackBox"))
                {
                        if (hit.transform != null)
                        {
                            Vector3 newPosition = hit.transform.position;
                            newPosition.x = newPosition.x + 6;
                            hit.transform.position = newPosition;
                            //Quaternion targetRotation = Quaternion.Euler(-40, 0, 0);
                           // transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2 * Time.deltaTime);

                        Vector3 batPosition = new Vector3(-78f, 4.89f, 109f);
                            batPosition.x = -72f;
                            batPosition.y = 6f;
                            battery.transform.position = batPosition;
                            blackBox.GetComponent<BoxCollider>().enabled = false;
                        }
                }

                else if(hit.collider.CompareTag("BlackBoxLid"))
                {   
                    if(hit.transform != null)
                    {
                        Vector3 newPosition = hit.transform.position;
                        newPosition.z = newPosition.z +5;
                        hit.transform.position = newPosition;
                        Quaternion targetRotation = Quaternion.Euler(-40,0, 0);
                        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2 * Time.deltaTime); 
                    }
                }

                else if (hit.collider.CompareTag("BatteryPack"))
                {
                
                  // if battery is in inventory, do something
                  //else print i need something for this to work
                  if (inventory.mItems.Contains(batRC1))//(IInventoryItem.get("Battery")))
                  {
                      inventory.RemoveItem(batRC1);
                      battery1RC.SetActive(true);
                      if(battery2RC.activeSelf){
                        rc.ChangeRotateState();
                    }


                    
                  }
                   else if (inventory.mItems.Contains(batRC2))
                  {
                      inventory.RemoveItem(batRC2);
                      battery2RC.SetActive(true);
                      if(battery1RC.activeSelf) {
                        rc.ChangeRotateState();
                    }
                     // print("This is the second battery!");
                  }
                //else if ()

                  else 
                  {
                    print ("You don't have anything in your inventory that works here.");
                  }
                }

                }
            }
        }
    }


