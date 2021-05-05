using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 10;
    int point = 1;
    public float speed = 0.1f;
    private Collider leftFootCollider;
    // Start is called before the first frame update

    void Update()
    {
        //transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 10;
        //transform.position += this.transform.forward * speed;
        transform.position += this.transform.up * speed;

        //Debug.Log(this.transform.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        //if (collision.gameObject.layer == 10)
        if (other.CompareTag("Enemy"))
        {

            //Debug.Log("hit");

            //GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().onDamage(damage);
            GameObject.Find("EnemyManager").GetComponent<EnemyCreation>().KillAndRevival(point);
            Destroy(other.gameObject);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
