using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//敵を作成するスクリプト
public class EnemyCreation : MonoBehaviour
{
    //public Text ;
    //public Text ObtainedPoint;
    //public int EnemyNum = 0;
    //public int SuperAtttackpoint = 0;
    public int EnemyNumManagementPoint;
    public GameObject GreenMonster;
    public GameObject SphereRobot;
    public GameObject Gundam;
    public GameObject RecoverTimeGreenMonster;

    public Transform ImageTarget;
    public Transform EnemyPoint1;
    public Transform EnemyPoint2;
    public Transform EnemyPoint3;
    public Transform EnemyPoint4;

    public ButtonState StartButton;
    public GameObject Timer;

    int enemyPointNum;
    //public ButtonState buttonB;
    //void Start()
    //{
    //    ObtainedPoint.text = "ぽいんと:" + EnemyNum;
    //}
    //// Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        EnemyNumManagementPoint = 0;    
    }
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

        //5対倒すごとに敵を5対増やす
        if(EnemyNumManagementPoint % 5 == 0 & EnemyNumManagementPoint != 0)
        {
            Debug.Log("enemyCreation");
            for(int l = 0; l < 3; l++)
            {
                CreateEnemy();
            }
            EnemyNumManagementPoint = 0;
        }
    }

    public void CreateEnemy()
    {
        //地面の4角から敵を生成
        ImageTarget = GameObject.Find("ImageTarget").transform;
        enemyPointNum = Random.Range(5, 6);
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
        else if (enemyPointNum == 5)
        {
            StartCoroutine("RecoverTimeGreenMonsterCreation");
        }

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
    IEnumerator RecoverTimeGreenMonsterCreation()
    {
        yield return new WaitForSeconds(5);
        Instantiate(RecoverTimeGreenMonster, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
    }

}
