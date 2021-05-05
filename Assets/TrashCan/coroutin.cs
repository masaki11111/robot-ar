using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutin : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

        Debug.Log("Before-Update");
        if (true)
        {
            StartCoroutine("Motion");
        }
        Debug.Log("After-Update");
    }

    private IEnumerator Motion()
    {
        for (int i = 0; i < 30; i++)
        {
            Debug.Log("--------Coroutine----------");
            yield return null;
        }


    }
}
////赤色にする
//gameObject.GetComponent<Renderer>().material.color = Color.red;

//    //3秒停止
//    yield return new WaitForSeconds(3);

//    //青色にする
//    gameObject.GetComponent<Renderer>().material.color = Color.blue;
//IEnumerator ChangeColor()