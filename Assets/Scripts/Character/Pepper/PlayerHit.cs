using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    Timer timer;
    public bool HitPlayer;

    // Start is called before the first frame update
    void Start()
    {
        HitPlayer = false;
        //timer = GameObject.Find("Timer").GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        if (other.CompareTag("Enemy"))
        {
            HitPlayer = true;
        }
    }
}
