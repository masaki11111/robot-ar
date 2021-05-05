using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine
//名前空間が以下だった
using Coffee.UIEffects;

public class Terminator_PlayerManager : MonoBehaviour
{
    Animator TerminatorAnimator;
    //float x=0.1f;
    //float y = 0.1f;
    public float speed;
    private Vector3 latestPos;
    private Collider leftFootCollider;
    public FixedJoystick joystick;
    public ButtonState buttonA;
    public ButtonState buttonB;

　　　//銃関連
    private Vector3 shotPos;
    public GameObject bullet;
    public GameObject Gun;
    public GameObject GunSit;
    public GameObject GunButton;
    int gunPoint;
    public AudioSource GunAudio;
    public AudioSource GunFillingAudio;

    //必殺技
    public GameObject SuperAttack;
    int superAttackPoint;

    EnemyCreation enemyCreation;
    int eHit;    

    //eHitの値を引き継ぐ
    int _eHit;

    // Start is called before the first frame update
    void Start()
    {
        enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();
        
        //Animator取得
        TerminatorAnimator =GameObject.Find("t-800_LP").GetComponent<Animator>();

        leftFootCollider = GameObject.Find("mixamorig:RightToeBase").GetComponent<SphereCollider>();
        leftFootCollider.enabled = false;

        //銃を非表示する
        GunSit.SetActive(false);
        //銃を非表示する
        Gun.SetActive(true);

        //初期化
        gunPoint = 0;
        superAttackPoint = 0;
    }

    void Update()
    {
        //EnemyNumの値を取得
        eHit = enemyCreation.EnemyNum;
        //gunPoint = enemyCreation.;
        superAttackPoint = enemyCreation.SuperAtttackpoint;

        //joystickを使って移動
        var input = new Vector3(joystick.Horizontal * (-1f), 0f, joystick.Vertical * (-1f)) * speed;
        this.transform.localPosition -= input;

        //Debug.Log("terminator"+this.transform.localPosition);
        //this.transform.localPosition += new Vector3(joystick.Horizontal * 0.05f, 0f,joystick.Vertical * 0.05f) * speed;
        //Debug.Log(joystick.Horizontal);

        //向き変更(ver1)
        //Vector3 direction = transform.position + input;
        //this.transform.LookAt(direction);

        //向き変更(ver2)
        Vector3 diff = transform.localPosition - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.localPosition;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        //0fにするとコントローラを話した瞬間に前を向く
        if (diff.magnitude > 0.0001f)
        {
            transform.localRotation = Quaternion.LookRotation(diff); //向きを変更する
        }
        //Debug.Log(this.transform.localPosition.magnitude);
        
        //アニメーション
        TerminatorAnimator.SetFloat("Speed", input.magnitude);

        //蹴り
            if (buttonA.IsDown())
            {
            //Debug.Log("Attack");
            TerminatorAnimator.SetTrigger("Attack");

            //swordをオンにする
            leftFootCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.0f);
        }

        if (eHit > 2)
        {
            //充填の音声
            GunFillingAudio.Play();
            //ボタンの色を変える
            GunButton.GetComponent<Image>().color = new Color(255f, 255f, 255f,166f);
            GunButton.GetComponent<UIShiny>().enabled = true;
            
            //必殺技
            if (buttonB.IsDown())
        {
            TerminatorAnimator.SetTrigger("SuperAttack");
            GunAudio.Play(); //add
            //玉の向きを合わせる
            Quaternion rotation = this.transform.rotation;
            Vector3 rotationAngles = rotation.eulerAngles;
            rotationAngles += new Vector3(90.0f, 0f, 0f);
            rotation = Quaternion.Euler(rotationAngles);

            ////位置をタブレットに合わせる
            shotPos = transform.position + new Vector3(0f, 0f, 0f);
            //Instantiate(bullet, this.transform.position, this.transform.rotation);
            Instantiate(bullet, shotPos, rotation);

            //銃を表示する
            GunSit.SetActive(true);
            //銃を非表示する
            Gun.SetActive(false);
            //一定時間後にコライダーの機能をオフにする
            Invoke("GunReset", 1.0f);
        }
        }
        if (superAttackPoint%4==0 && superAttackPoint!=0)
        {
            Debug.Log("SuperAttackOn");
            //superattackは先にオフにしておく
            SuperAttack.transform.localPosition = this.transform.localPosition;
            SuperAttack.SetActive(true);
            this.transform.localPosition = new Vector3(999f, 999f, 999f);
            this.gameObject.SetActive(false);
            //superAttackPoint = 0;
        }


    }
    private void ColliderReset()
    {
        leftFootCollider.enabled = false;
    }

    private void GunReset()
    {
        //銃を表示する
        Gun.SetActive(true);
        //銃を表示する
        GunSit.SetActive(false);
    }
}
