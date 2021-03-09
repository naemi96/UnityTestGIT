using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLine : MonoBehaviour
{

    LineRenderer link;
    public Transform[] pos;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        link = gameObject.GetComponent<LineRenderer>();  
    }

    
    void Update()
    {
        link.SetPosition(0, pos[0].position);
        link.SetPosition(1, Vector3.MoveTowards(transform.position, pos[1].position, speed * Time.time));
    }
}
