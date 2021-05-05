using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    ParticleSystem FlameThrower;
    // Start is called before the first frame update
    void Start()
    {
        FlameThrower = GameObject.Find("FlameThrower").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            FlameThrower.Play();
        }
    }
}
