using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;

    Vector3 shotPos;
    Quaternion shotRot;
    //public float rx;
    //public float ry;
    //public float rz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //角度変更
            Quaternion rotation = this.transform.rotation;
            Vector3 rotationAngles = rotation.eulerAngles;
            rotationAngles += new Vector3(90.0f, 0f, 0f);
            rotation = Quaternion.Euler(rotationAngles);

            ////位置をタブレットに合わせる
            shotPos = transform.position + new Vector3(0f, 0f, 0f);
            //Instantiate(bullet, this.transform.position, this.transform.rotation);
            Instantiate(bullet, shotPos, rotation);
        }
    }
}
