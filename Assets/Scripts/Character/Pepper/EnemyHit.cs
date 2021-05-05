using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class EnemyHit : MonoBehaviour
{
    int damage = 10;
    //攻撃が当たったときのダメージの数値
    int point = 1;
    private Collider leftFootCollider;
    //ダメージが当たったときの効果音
    public AudioSource Hit;
    public AudioClip impact;
    //敵の位置
    private Vector3 EnemyPos;
    private Vector3 HitPos;
    //ダメージが当たったときのエフェクト
    public GameObject HitParticleObject;
    public Transform ImageTarget;

    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        //if (collision.gameObject.layer == 10)
            if(other.CompareTag("Enemy"))
        {
            //ダメージの数値を渡す
            GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().KillAndRevival(point);

            //ダメージを与えた時に効果音を出す
            Hit = gameObject.GetComponent<AudioSource>();
            Hit.PlayOneShot(impact);

            //攻撃が当たった敵を消す＆当たったところに煙のエフェクトを出す
            EnemyPos = other.gameObject.transform.position;
            Destroy(other.gameObject);
            Instantiate(HitParticleObject,EnemyPos,Quaternion.identity,ImageTarget);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
