using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//敵を作成するスクリプト
public class EnemyCreation : MonoBehaviour
{
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

    //public ButtonState StartButton;
    //public GameObject Timer;

    int enemyPointNum;
    void Start()
    {
        EnemyNumManagementPoint = 0;
        ImageTarget = GameObject.Find("ImageTarget").transform;
        //ImageTarget = GameObject.Find("ImageTarget").transform;

    }
    void Update()
    {

        //20対倒すごとに敵を5対増やす
        if(EnemyNumManagementPoint % 20 == 0 & EnemyNumManagementPoint != 0)
        {
            //Debug.Log("enemyCreation");
            for(int l = 0; l < 5; l++)
            {
                CreateEnemy();
            }
            EnemyNumManagementPoint = 0;
        }
    }

    public void CreateEnemyForFirstTime()
    {
        for (int r = 1; r <= 5; r++)
        {
            Instantiate(GreenMonster, EnemyPoint1.position, EnemyPoint1.rotation, ImageTarget);
            //Debug.Log("what?111");
            Instantiate(Gundam, EnemyPoint2.position, EnemyPoint2.rotation, ImageTarget);
            Instantiate(SphereRobot, EnemyPoint3.position, EnemyPoint3.rotation, ImageTarget);
            Instantiate(SphereRobot, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
        }

    }

    public void CreateEnemy()
    {
        //地面の4角から敵を生成
        enemyPointNum = Random.Range(1, 85);
        if (enemyPointNum <20)
        {
            StartCoroutine("GreenMonsterCreation");
        }
        else if (enemyPointNum >= 20 && enemyPointNum < 40 )
        {
            StartCoroutine("GundamMonsterCreation");
        }
        else if (enemyPointNum >= 40 && enemyPointNum < 60)
        {
            StartCoroutine("SphereRobot3Creation");
        }
        else if (enemyPointNum >= 60 && enemyPointNum < 80)
        {
            StartCoroutine("SphereRobot4Creation");
        }
        else if (enemyPointNum >= 80 && enemyPointNum < 81)
        {
            StartCoroutine("RecoverTimeGreenMonster1Creation");
        }
        else if (enemyPointNum >= 81 && enemyPointNum < 82)
        {
            StartCoroutine("RecoverTimeGreenMonster2Creation");
        }
        else if (enemyPointNum >= 82 && enemyPointNum < 83)
        {
            StartCoroutine("RecoverTimeGreenMonster3Creation");
        }
        else if (enemyPointNum >= 83 && enemyPointNum < 84)
        {
            StartCoroutine("RecoverTimeGreenMonster4Creation");
        }


    }


    IEnumerator GreenMonsterCreation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(GreenMonster, EnemyPoint1.position, EnemyPoint1.rotation, ImageTarget);
    }
    IEnumerator GundamMonsterCreation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Gundam, EnemyPoint2.position, EnemyPoint2.rotation, ImageTarget);
    }
    IEnumerator SphereRobot3Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(SphereRobot, EnemyPoint3.position, EnemyPoint3.rotation, ImageTarget);
    }
    IEnumerator SphereRobot4Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(SphereRobot, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
    }
    IEnumerator RecoverTimeGreenMonster1Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(RecoverTimeGreenMonster, EnemyPoint1.position, EnemyPoint4.rotation, ImageTarget);
    }
    IEnumerator RecoverTimeGreenMonster2Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(RecoverTimeGreenMonster, EnemyPoint2.position, EnemyPoint4.rotation, ImageTarget);
    }
    IEnumerator RecoverTimeGreenMonster3Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(RecoverTimeGreenMonster, EnemyPoint3.position, EnemyPoint4.rotation, ImageTarget);
    }
    IEnumerator RecoverTimeGreenMonster4Creation()
    {
        yield return new WaitForSeconds(1);
        Instantiate(RecoverTimeGreenMonster, EnemyPoint4.position, EnemyPoint4.rotation, ImageTarget);
    }

}
