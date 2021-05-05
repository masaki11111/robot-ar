using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Plane;
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        
      

    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.position = GameObject.Find("Plane").transform.position;
        //Instantiate(Enemy, Enemy.transform.TransformPoint(Enemy.transform.localPosition + new Vector3(0.4f, 0, 0.4f)), Enemy.transform.rotation, Enemy.transform);
        if (Input.GetKeyDown(KeyCode.A))
        {

            //Instantiate(Enemy, Plane.transform.TransformPoint(Plane.transform.localPosition + new Vector3(0.4f, 0, 0.4f)),Plane.transform.rotation, Plane.transform);
            Instantiate(Enemy, transform.position + new Vector3(4f, 0, 4f), Plane.transform.rotation, Plane.transform);
            //Instantiate(Enemy, Enemy.transform.TransformPoint(Enemy.transform.position), Enemy.transform.rotation, Enemy.transform);
        }
    }
}
