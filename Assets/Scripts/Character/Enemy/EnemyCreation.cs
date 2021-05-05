using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//敵を作成するスクリプト
public class EnemyCreation : MonoBehaviour
{
    //public Text ;
    public Text ObtainedPoint;
    //int HP = 10;
    public int EnemyNum = 0;
    public int SuperAtttackpoint = 0;
    public GameObject GreenMonster;
    public GameObject SphereRobot;
    public GameObject Gundam;
    public GameObject Pepper;

    public Transform ImageTarget;
    public Transform EnemyPoint1;
    public Transform EnemyPoint2;
    public Transform EnemyPoint3;
    public Transform EnemyPoint4;

    public ButtonState StartButton;
    public GameObject Timer;

    int enemyPointNum;
    //public ButtonState buttonB;
    void Start()
    {
        ObtainedPoint.text = "ぽいんと:" + EnemyNum;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //初期状態で１０体生成
        //if (Input.GetKeyDown(KeyCode.A))
        if (StartButton.IsDown())
        {
            Timer.GetComponent<Timer>().enabled = true;
            ImageTarget = GameObject.Find("ImageTarget").transform;

            for (int r = 1; r <= 5; r++)
            {
                Instantiate(GreenMonster, EnemyPoint1.position, EnemyPoint1.rotation, ImageTarget);
                //Debug.Log("what?111");
                Instantiate(Gundam, EnemyPoint2.position, EnemyPoint2.rotation, ImageTarget);
                Instantiate(SphereRobot, EnemyPoint3.position, EnemyPoint3.rotation, ImageTarget);
                Instantiate(SphereRobot, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
            }
        }
    }

    public void KillAndRevival(int _point)
    {
        //地面の4角から敵を生成
        ImageTarget = GameObject.Find("ImageTarget").transform;
        enemyPointNum = Random.Range(1, 5);
        if (enemyPointNum == 1)
        {
            StartCoroutine("GreenMonsterCreation");
        }
        else if (enemyPointNum == 2)
        {
            StartCoroutine("GundamMonsterCreation");
        }
        else if (enemyPointNum == 3)
        {
            StartCoroutine("SphereRobot3Creation");
        }
        else if (enemyPointNum == 4)
        {
            StartCoroutine("SphereRobot4Creation");
        }

        //点数管理
        EnemyNum += _point;
        ObtainedPoint.text = "ぽいんと" + EnemyNum;
        SuperAtttackpoint += _point;


    }

    IEnumerator GreenMonsterCreation()
    {
        yield return new WaitForSeconds(5);
        Instantiate(GreenMonster, EnemyPoint1.position, EnemyPoint1.rotation, ImageTarget);
    }
    IEnumerator GundamMonsterCreation()
    {
        yield return new WaitForSeconds(5);
        Instantiate(Gundam, EnemyPoint2.position, EnemyPoint2.rotation, ImageTarget);
    }
    IEnumerator SphereRobot3Creation()
    {
        yield return new WaitForSeconds(5);
        Instantiate(SphereRobot, EnemyPoint4.position, EnemyPoint3.rotation, ImageTarget);
    }
    IEnumerator SphereRobot4Creation()
    {
        yield return new WaitForSeconds(5);
        Instantiate(SphereRobot, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
    }


}
