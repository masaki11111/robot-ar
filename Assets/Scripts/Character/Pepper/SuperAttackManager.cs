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

public class SuperAttackManager : MonoBehaviour
{
    //必殺技
    public ButtonState buttonB;
    GameObject Earth;
    int superAttackPoint;
    ParticleSystem EarthShatter1;
    ParticleSystem EarthShatter2;
    ParticleSystem EarthShatter3;
    ParticleSystem EarthShatter4;
    ParticleSystem EarthShatter5;
    ParticleSystem EarthShatter6;
    ParticleSystem EarthShatter7;
    ParticleSystem EarthShatter8;
    BoxCollider EarthCollider;
    float EarthLength;
    public GameObject superAttackButton;
    GameObject superAttackTrigger;
    //public Color superAttackButtonImage;
    public AudioSource superAttackAudio;
    public AudioSource superAttackButtonAudio;
    EnemyCreation enemyCreation;
    int eHit;
    int count;
    Animator SuperAttackImageCutin;
    //Volume SuperAttackVolume;
    private PostProcessVolume postProcessVolume;
    ColorGrading _colorGrading;
    public float timeOut;
    private float timeElapsed;
    bool waitforcutin;
    //eHitの値を引き継ぐ
    int _eHit;



    // Start is called before the first frame update
    void Start()
    {
        enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();

        //必殺技初期化
        //superAttackPoint = 0;
        Earth = GameObject.Find("EarthShatter");
        EarthShatter1 = GameObject.Find("EarthShatter1").GetComponent<ParticleSystem>();
        EarthShatter2 = GameObject.Find("EarthShatter2").GetComponent<ParticleSystem>();
        EarthShatter3 = GameObject.Find("EarthShatter3").GetComponent<ParticleSystem>();
        EarthShatter4 = GameObject.Find("EarthShatter4").GetComponent<ParticleSystem>();
        EarthShatter5 = GameObject.Find("EarthShatter5").GetComponent<ParticleSystem>();
        EarthShatter6 = GameObject.Find("EarthShatter6").GetComponent<ParticleSystem>();
        EarthShatter7 = GameObject.Find("EarthShatter7").GetComponent<ParticleSystem>();
        EarthShatter8 = GameObject.Find("EarthShatter8").GetComponent<ParticleSystem>();
        EarthCollider = Earth.GetComponent<BoxCollider>();
        Earth.SetActive(false);
        SuperAttackImageCutin = GameObject.Find("SuperAttackImage").GetComponent<Animator>();
        superAttackTrigger = GameObject.Find("SuperAttackTrigger");
        count = 0;
        //superAttackButtonImage=superAttackButton.GetComponent<Image>().color;
        //EarthCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //EnemyNumの値を取得
        eHit = enemyCreation.EnemyNum;
        //gunPoint = enemyCreation.GunPoint;
        superAttackPoint = enemyCreation.SuperAtttackpoint;

        //敵を倒して２０ポイント溜まったら必殺技を打てる様にする
        if (superAttackPoint % 20 == 0 && superAttackPoint != 0)
        //if (superAttackPoint % 1 == 0)
        {

            superAttackButton.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 166 / 255f);
            //Debug.Log("imagecolor");
            superAttackButton.GetComponent<UIShiny>().enabled = true;
            superAttackTrigger.SetActive(false);

        }
        if (buttonB.IsDown())
        {
            Debug.Log("SuperAttackOn");
            superAttackButtonAudio.Play();
            SuperAttackImageCutin.SetTrigger("SuperAttack");
            waitforcutin = true;
            //Earth.SetActive(true);

            // PostProcessVolume にスタックされた Effect が格納された配列 PostProcessVolume.profile.settings から ColorGrading を探して参照する
            postProcessVolume = GameObject.Find("ARCamera").gameObject.GetComponent<PostProcessVolume>();
            foreach (PostProcessEffectSettings item in postProcessVolume.profile.settings)
            {
                if (item as ColorGrading)
                {
                    _colorGrading = item as ColorGrading;
                };
            }
            // エフェクトのパラメータに値を代入する
            if (_colorGrading)
            {
                _colorGrading.colorFilter.value = new Color(75 / 255f, 75 / 255f, 75 / 255f);
            }

            //cutinが入って2秒アニメーションとコライダーを止める
            //System.Threading.Thread.Sleep(2000);
            //this.transform.localPosition = new Vector3(999f, 999f, 999f);
            //EarthShatter1.Play();
            //superattackは先にオフにしておく
            //SuperAttack.SetActive(true);
            //this.gameObject.SetActive(false);
            //superAttackPoint = 0;
        }
        if (waitforcutin)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 2.0f)
            {
                // Do anything
                Earth.SetActive(true);
                StartCoroutine("SuperAttack");
                timeElapsed = 0.0f;
                waitforcutin = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (Earth.activeSelf == true)
        {
            if (count < 2)
            {
                if (EarthLength <= 9)
                {
                    EarthLength += 0.3f;
                    EarthCollider.size = new Vector3(EarthLength, 10, EarthLength);
                    //EarthPosition += 1.87f;
                    //EarthCollider.center = new Vector3(0, -12, FlamePosition);
                }
                else if (EarthLength > 9 && EarthLength < 9.57)
                {
                    EarthLength += 0.01f;
                }
                else
                {
                    count += 1;
                    EarthLength = 0;
                }
            }
            if (count >= 2)
            {
                if (EarthLength <= 17)
                {
                    EarthLength += 0.71f;
                    EarthCollider.size = new Vector3(EarthLength, 10, EarthLength);
                }
                else if (EarthLength > 17 && EarthLength < 17.5)
                {
                    EarthLength += 0.01f;
                }
                else
                {
                    count = 0;
                    EarthLength = 0;
                    EarthCollider.size = new Vector3(EarthLength, 10, EarthLength);
                    superAttackButton.GetComponent<Image>().color = new Color(60 / 255f, 60 / 255f, 60 / 255f, 166 / 255f);
                    Debug.Log("imagecolor2");
                    superAttackButton.GetComponent<UIShiny>().enabled = false;
                    superAttackTrigger.SetActive(true);
                    Earth.SetActive(false);
                    _colorGrading.colorFilter.value = new Color(255 / 255f, 255 / 255f, 255 / 255f);

                }
            }
        }

    }
    IEnumerator SuperAttack()
    {
        //Earth.SetActive(true);
        //アニメーション
        superAttackAudio.Play();
        EarthShatter1.Play();
        EarthShatter2.Play();
        EarthShatter3.Play();
        EarthShatter4.Play();
        Debug.Log("c1");
        //3秒停止
        yield return new WaitForSeconds(2);
        //アニメーション
        superAttackAudio.Play();
        EarthShatter1.Play();
        EarthShatter2.Play();
        EarthShatter3.Play();
        EarthShatter4.Play();
        Debug.Log("c2");
        yield return new WaitForSeconds(2);
        superAttackAudio.Play();
        EarthShatter5.Play();
        EarthShatter6.Play();
        EarthShatter7.Play();
        EarthShatter8.Play();
        yield return new WaitForSeconds(0.2f);
        superAttackAudio.Play();

        yield return new WaitForSeconds(5);

    }
}
