using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input)
        //this.transform.localPosition -=

        if (Input.GetKeyDown(KeyCode.Space))
        {

            this.transform.localPosition += new Vector3(0f, 0.4f, 0f);
            Debug.Log("Space" + this.transform.position);

        }
    }
}
