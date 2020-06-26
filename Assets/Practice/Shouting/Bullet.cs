//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    int damage = 10;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 10;
        //transform.position += this.transform.forward * speed;
        transform.position += this.transform.up * speed;

        //Debug.Log(this.transform.forward);
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Enemy")

    //    {
    //        collision.gameObject.GetComponent<Enemy>().onDamage(damage);
    //        Destroy(this.gameObject);

    //        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        //if (collision.gameObject.layer == 10)
        if (other.CompareTag("Enemy"))
        {

            Debug.Log("hit");
            other.gameObject.GetComponent<Enemy_1>().onDamage(damage);
            //Destroy(this.gameObject);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

