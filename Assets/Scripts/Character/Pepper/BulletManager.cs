using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine
//名前空間が以下だった
using Coffee.UIEffects;
using System.Threading;
//using System.Threading.Task;
using UnityEngine.Rendering;//必要
//using UnityEngine.Rendering.Universal//必要;
using UnityEngine.Rendering.PostProcessing;

public class BulletManager : MonoBehaviour
{
    // bullet prefab
    public GameObject bullet;
    // 弾丸発射点
    public Transform muzzle;
    //炎
    public ButtonState buttonA;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // z キーが押された時
        //if (Input.GetKeyDown(KeyCode.Z))

        if (buttonA.IsDown())
        {
            //Debug.Log("ZZZ");
            // 弾丸の複製
            //GameObject bullets = Instantiate(bullet) as GameObject;
            Instantiate(bullet, muzzle.position, muzzle.rotation, muzzle);

            //Vector3 force;

            //force = this.gameObject.transform.forward * speed;

            // Rigidbodyに力を加えて発射
            //bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            //bullets.transform.position = muzzle.position;
        }
    }
    //public void BulletDestroy
    //{
    //    Destroy(this.gameObject);

    //}
}
