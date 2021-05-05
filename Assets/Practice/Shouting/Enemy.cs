using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text HPText;
    int HP=10;
    public GameObject Enemy_1;
    Vector3 enemyPos; 
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
            Destroy(this.gameObject);
            Vector3 _enemyPos = new Vector3(Random.Range(-0.8f, 0.8f), 0f, Random.Range(-0.8f, 0.8f));
            //enemyPos=
            //Instantiate(Enemy_1, shotPos, rotation);
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
