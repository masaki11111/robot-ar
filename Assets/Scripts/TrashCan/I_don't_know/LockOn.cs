using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Lock"))
        {
            if (target == null)
            {
                target = GameObject.Find("Enemy");
            }
            else
            {
                target = null;
            }

        }
        if (target != null)
        {
            Debug.Log(target.transform);
            transform.LookAt(target.transform);
        }
    }
}
