using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        leftFootCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

        //var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed;
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
        Debug.Log(this.transform.localPosition.magnitude);

        //アニメーション
        animator.SetFloat("Speed", input.magnitude);

        //if (Input.GetKeyDown(KeyCode.Space))
            if (buttonA.IsDown()| buttonB.IsDown())
            {
            animator.SetTrigger("Attack");


            //print("ButtonA Down: " + buttonA.IsDown());
            //print("ButtonB Down: " + buttonB.IsDown());

            //swordをオンにする
            leftFootCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }
    }
    private void ColliderReset()
    {
        leftFootCollider.enabled = false;
    }


}

