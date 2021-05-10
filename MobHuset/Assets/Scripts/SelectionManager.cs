using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string selectableButton = "Button";
    [SerializeField] private string selectableCar = "Car";

    public GameObject buttonText; 
    public GameObject kassaText;
    public bool isHighlighted = false;
    public bool isHighlightedKassa = false;

  //  public GameObject penText;
    public bool isHighlightedPen = false;

    public GameObject whiteboardText;


    private Transform _selection;

    IEnumerator WaitForSecButton()
    {
        if (!isHighlighted)
        {
            isHighlighted = true;
            yield return new WaitForSeconds(1);
            isHighlighted = false;
            buttonText.SetActive(false);
        }
    }

   /* IEnumerator WaitForSecPen()
    {
        if (!isHighlighted)
        {
            isHighlighted = true;
            yield return new WaitForSeconds(1);
            isHighlighted = false;
          //  penText.SetActive(false);
        }
    } */

    IEnumerator WaitForSecWhiteboard()
    {
        if (!isHighlighted)
        {
            isHighlighted = true;
            yield return new WaitForSeconds(1);
            isHighlighted = false;
            whiteboardText.SetActive(false);
        }
    }

    IEnumerator WaitForSecKassa()
    {
        if (!isHighlightedKassa)
        {
            isHighlightedKassa = true;
            yield return new WaitForSeconds(1);
            isHighlightedKassa = false;
            kassaText.SetActive(false);
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;


            //if selectionRender.materials = längre än 2, gå in och ändra material till
            //default material. gör while/for loop med count

            if (_selection.CompareTag(selectableCar))
            {
                Material[] materials = selectionRenderer.materials;
                materials[0] = defaultMaterial;
                materials[1] = defaultMaterial;
                materials[2] = defaultMaterial;
                materials[5] = defaultMaterial;
                selectionRenderer.materials = materials;
                
            }

            if (_selection.CompareTag("Battery"))
            {
                Material[] materials = selectionRenderer.materials;
                materials[0] = defaultMaterial;
                selectionRenderer.materials = materials;
                
            }
             _selection = null;
           
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("RotateButton"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }
        }



        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("On/Off"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }
        }


        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableButton))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Button"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null  && isHighlighted == false)
            {
                selectionRenderer.material = highlightMaterial;
                buttonText.SetActive(true);
                StartCoroutine("WaitForSecButton");
            }
            _selection = selection;
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Kassa"))
            {
                kassaText.SetActive(true);
                StartCoroutine("WaitForSecKassa");
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Skärm"))
            {
                whiteboardText.SetActive(true);
                StartCoroutine("WaitForSecWhiteboard");
            }
        }

        //if (Physics.Raycast(ray, out hit))
      //  {
       //     var selection = hit.transform;
        //    if (selection.CompareTag("Pen"))
        //    {
        //        penText.SetActive(true);
        //        StartCoroutine("WaitForSecPen");
        //    }
     //   }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Button2"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null  && isHighlighted == false)
            {
                selectionRenderer.material = highlightMaterial;
                buttonText.SetActive(true);
                StartCoroutine("WaitForSecButton");
            }
            _selection = selection;
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Book1"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }

            if (selection.CompareTag("Book2"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }

            if (selection.CompareTag("Book3"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }

            if (selection.CompareTag("Book4"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }

            if (selection.CompareTag("Battery"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;
            }

            if (selection.CompareTag("BlackBox"))
            {
                Vector3 defaultPosition = new Vector3(-75f,6.5f,111f);
                    if(hit.transform.position == defaultPosition)
                    {
                        print ("You are now at the black box");
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            selectionRenderer.material = highlightMaterial;
                        }
                        _selection = selection;
                    }

                if (selection.CompareTag("BlackBoxLid"))
                {
                    var selectionRenderer1 = selection.GetComponent<Renderer>();
                    if (selectionRenderer1 != null)
                    {
                        selectionRenderer1.material = highlightMaterial;
                    }
                    _selection = selection;
                }
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableCar))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                Material[] materials = selectionRenderer.materials;

                //MeshRenderer myRend = selection.GetComponent<MeshRenderer>();
                //Material[] materials = myRend.materials;
                //print(materials);
            

            if (selectionRenderer!= null)
            {   
                materials[0] = highlightMaterial;
                materials[1] = highlightMaterial;
                materials[2] = highlightMaterial;
                materials[5] = highlightMaterial;
                selectionRenderer.materials = materials;

            }
            _selection = selection;
            }
        }
    }
}
