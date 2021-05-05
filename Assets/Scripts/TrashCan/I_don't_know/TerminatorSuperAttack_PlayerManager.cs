using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TerminatorSuperAttack_PlayerManager : MonoBehaviour
{
    Animator animator;
    float x = 0.1f;
    float y = 0.1f;
    public float speed;
    private Vector3 latestPos;
    private Collider leftFootCollider;
    public FixedJoystick joystick;
    public ButtonState buttonA;
    public ButtonState buttonB;
    Vector3 shotPos;
    public GameObject bullet;
    public AudioSource BikeAudio;
    public int audioStrength;

    EnemyCreation enemyCreation;
    public Text superAttackTimerText;
    public float superAttackTotalTime;
    int seconds;
   
    public GameObject normalTerminator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        BikeAudio.Play();
        audioStrength = 10;
        enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();

    }
    // Update is called once per frame
    void Update()
    {


        //バーチャルコントローラで移動
        var input = new Vector3(joystick.Horizontal * (-1f), 0f, joystick.Vertical * (-1f)) * speed;
        //var input = new Vector3(joystick.Vertical * (-1f), 0f, joystick.Horizontal * (-1f)) * speed;
        this.transform.localPosition -= input;

        //this.transform.localPosition += new Vector3(joystick.Horizontal * 0.05f, 0f,joystick.Vertical * 0.05f) * speed;
        //Debug.Log(joystick.Horizontal);

        //向き変更(ver2)
        Vector3 diff = transform.localPosition - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.localPosition;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.0001f)
        {
            transform.localRotation = Quaternion.LookRotation(diff); //向きを変更する
        }
        //Debug.Log(this.transform.localPosition.magnitude);

        BikeAudio.volume = input.magnitude * audioStrength;



        superAttackTotalTime -= Time.deltaTime;
        seconds = (int)superAttackTotalTime;
        superAttackTimerText.text = seconds.ToString();

        if (seconds <= 0)
        {

            Debug.Log("finish");
            superAttackTotalTime = 10;
            enemyCreation.SuperAtttackpoint=0;
            normalTerminator.transform.localPosition = this.transform.localPosition;
            normalTerminator.SetActive(true);
            this.gameObject.SetActive(false);

        }


    }
}
