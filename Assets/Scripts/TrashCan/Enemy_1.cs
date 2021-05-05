using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour
{
    public Text HPText;
    int HP = 50;
    public GameObject Enemy;
    Transform enemy;
    void Start()
    {
        HPText.text = "HP:" + HP;
    }

    public void onDamage(int _damage)
    {
        HP -= _damage;
        Debug.Log(HP);
        HPText.text = "HP:" + HP;
        if (HP <= 0)
        {
            HP = 50;

            //Vector3 _enemyPos = new Vector3(Random.Range(-0.4f, 0.4f), 0f, Random.Range(-0.4f, 0.4f));
            //Vector3 _enemyPos = new Vector3(0.4f, 0f, 0.4f);
            //this.transform.localPosition = _enemyPos;
            //　位置をローカル→ワールドへと変える
            
            //Debug.Log(this.transform.localPosition);

            enemy = GameObject.Find("Plane").transform;
            //enemy.localPosition += _enemyPos;
            //enemy.position=enemy.TransformPoint(enemy.localPosition);
            //Instantiate(Enemy, transform.TransformPoint(enemy.localPosition+new Vector3(4f,0,4f)), this.transform.localRotation);

        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}
