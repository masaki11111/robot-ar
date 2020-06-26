using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper_PlayerManager : MonoBehaviour
{
    Animator animator;
    float x=0.1f;
    float y = 0.1f;
    public float speed;
    private Vector3 latestPos;
    private Collider leftFootCollider;
    public FixedJoystick joystick;
    public ButtonState buttonA;
    public ButtonState buttonB;
    Vector3 shotPos;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }
    // Update is called once per frame
    void Update()
    {
        //バーチャルコントローラで移動
        var input = new Vector3(joystick.Horizontal*(-1f), 0f, joystick.Vertical*(-1f)) * speed;
        this.transform.localPosition -= input;

        //this.transform.localPosition += new Vector3(joystick.Horizontal * 0.05f, 0f,joystick.Vertical * 0.05f) * speed;
        //Debug.Log(joystick.Horizontal);

        //向き変更(ver1)
        //Vector3 direction = transform.position + input;
        //this.transform.LookAt(direction);

        //向き変更(ver2)
        Vector3 diff = transform.localPosition - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.localPosition;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.localRotation = Quaternion.LookRotation(diff); //向きを変更する
        }
        //Debug.Log(this.transform.localPosition.magnitude);

        //アニメーション
        //animator.SetFloat("Speed", input.magnitude);

        //if (Input.GetKeyDown(KeyCode.Space))
        if (buttonA.IsDown() | buttonB.IsDown())
        {
            //animator.SetTrigger("Attack");
            //角度変更
            Quaternion rotation = this.transform.rotation;
            Debug.Log("rotation"+rotation);
            Vector3 rotationAngles = rotation.eulerAngles;
            Debug.Log("rotationAngles"+rotationAngles);
            rotationAngles += new Vector3(90.0f, 0f, 0f);
            Debug.Log("rotationAngles"+rotationAngles);
           
            //rotationAngles += new Vector3(0.0f, 0f, 0f);
            rotation = Quaternion.Euler(rotationAngles);
            Debug.Log("rotation"+rotation);
            ////位置をタブレットに合わせる
            shotPos = transform.position + new Vector3(0f, 0f, 0f);
            //Instantiate(bullet, this.transform.position, this.transform.rotation);
            Instantiate(bullet, shotPos, rotation);

            //print("ButtonA Down: " + buttonA.IsDown());
            //print("ButtonB Down: " + buttonB.IsDown());

            //swordをオンにする
            //leftFootCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            //Invoke("ColliderReset", 1.5f);
        }
    }
    private void ColliderReset()
    {
        leftFootCollider.enabled = false;
    }


}

