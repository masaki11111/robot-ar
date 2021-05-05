using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject GunSit;

    // Start is called before the first frame update
    void Start()
    {
        GunSit = GameObject.Find("GunSit");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
