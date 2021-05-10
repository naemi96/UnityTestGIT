using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcCar : MonoBehaviour
{
    public RC rc;
    public GameObject headlights;
    public GameObject frontlights;

    [SerializeField] private Material lightMaterial;

    //set active lamps in lounge?
    public GameObject MainPL;

    //This is the car that should start driving which the player should follow.
    //Headlights need to turn on; lights should be set to active.
        //this indicates that the car is turned on.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rc.hasBatteries == true)
        
        {
            GameObject[] mLights = GameObject.FindGameObjectsWithTag("GLow");
            foreach (GameObject mLight in mLights)
            {
                Renderer[] renderers = mLight.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    int i = 0;
                    Material[]mMaterials = renderer.materials;
                    foreach (Material material in renderer.materials)
                    {
                        mMaterials[i++] = lightMaterial;
                    }
                    renderer.materials = mMaterials;
                }
            }
            
            headlights.SetActive(true);
            frontlights.SetActive(true);

            MainPL.SetActive(true);
        }
    }
}
