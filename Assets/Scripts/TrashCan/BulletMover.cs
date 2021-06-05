using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed = 0.1f;
    
    void Update()
    {
        //transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 10;
        //transform.position += this.transform.forward * speed;
        this.transform.position += this.transform.forward * speed;

        //Debug.Log(this.transform.forward);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    //enemyに当たった時
    //    //if (collision.gameObject.layer == 10)
    //    if (other.CompareTag("Enemy") || other.CompareTag("RecoverTimeEnemy"))
    //    {
            
    //        //Debug.Log("hit");

    //        //        //GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().onDamage(damage);
    //        //        //GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().CreateEnemy;
    //        //        //Destroy(other.gameObject);

    //        //        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        //    }
    //    }
    //}
}
