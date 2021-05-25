using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class name : MonoBehaviour
{
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//メタルスライムならタイムを十秒増やす
        if (box.name == "box")
        {
            Debug.Log("1");
        }
    }
}
