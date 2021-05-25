using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class EnemyHit : MonoBehaviour
{
    int point = 1;
    ObtainedPointManager obtainedPointManager;
    SuperAttackManager superAttackManager;
    EnemyCreation enemyCreation;

    //private Collider leftFootCollider;
    //ダメージが当たったときの効果音
    public AudioSource Hit;
    public AudioClip impact;
    //敵の位置
    private Vector3 EnemyPos;
    //private Vector3 HitPos;
    //ダメージが当たったときのエフェクト
    public GameObject HitParticleObject;
    public Transform ImageTarget;
    Timer timer;

    private void Start()
    {
        obtainedPointManager = GameObject.Find("Point").GetComponent<ObtainedPointManager>();
        superAttackManager = GameObject.Find("Pepper").GetComponent<SuperAttackManager>();
        enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();

        //EnemyNumManagementPoint = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        if (other.CompareTag("Enemy"))
        {
            ////メタルスライムならタイムを十秒増やす
            //Debug.Log("barvalue");
            //timer.RecoverTIme();

            //ダメージの数値を渡す
            GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().CreateEnemy();

            //点数管理
            obtainedPointManager._ObtainedPoint += point;
            enemyCreation.EnemyNumManagementPoint += point;
            obtainedPointManager.ObtainedPoint.text = "ぽいんと:" + obtainedPointManager._ObtainedPoint;
            superAttackManager.superAttackPoint += point;

            //ダメージを与えた時に効果音を出す
            Hit = gameObject.GetComponent<AudioSource>();
            Hit.PlayOneShot(impact);

            //攻撃が当たった敵を消す＆当たったところに煙のエフェクトを出す
            EnemyPos = other.gameObject.transform.position;
            Destroy(other.gameObject);
            Instantiate(HitParticleObject, EnemyPos, Quaternion.identity, ImageTarget);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        //メタルスライムならタイムを十秒増やす
        else if (other.CompareTag("RecoverTimeEnemy"))
        {
            Debug.Log("barvalue");
            timer.RecoverTIme();

            //ダメージの数値を渡す
            GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().CreateEnemy();

            //点数管理
            obtainedPointManager._ObtainedPoint += point;
            enemyCreation.EnemyNumManagementPoint += point;
            obtainedPointManager.ObtainedPoint.text = "ぽいんと:" + obtainedPointManager._ObtainedPoint;
            superAttackManager.superAttackPoint += point;

            //ダメージを与えた時に効果音を出す
            Hit = gameObject.GetComponent<AudioSource>();
            Hit.PlayOneShot(impact);

            //攻撃が当たった敵を消す＆当たったところに煙のエフェクトを出す
            EnemyPos = other.gameObject.transform.position;
            Destroy(other.gameObject);
            Instantiate(HitParticleObject, EnemyPos, Quaternion.identity, ImageTarget);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}

