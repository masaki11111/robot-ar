using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour
{
    public Text HPText;
    int HP = 10;
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
            HP = 0;
            
            Vector3 _enemyPos = new Vector3(Random.Range(-0.8f, 0.8f), 0f, Random.Range(-0.8f, 0.8f));
            enemy= GameObject.Find("Plane").transform;
            enemy.localPosition += _enemyPos;
            enemy.position=enemy.TransformPoint(enemy.localPosition);
            Instantiate(Enemy, enemy.position,enemy.rotation);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}
