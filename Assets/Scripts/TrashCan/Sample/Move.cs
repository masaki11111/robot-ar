using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //rb = GetComponent<Rigidbody>();
            //rb.velocity = new Vector3(0.01f, 0, 0);
            this.transform.localPosition += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //rb = GetComponent<Rigidbody>();
            //rb.velocity = new Vector3(0.01f, 0, 0);
            this.transform.localPosition += new Vector3(0.1f, 0, 0);
        }
    }
}
