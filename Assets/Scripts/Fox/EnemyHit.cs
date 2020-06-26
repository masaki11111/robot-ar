using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    int damage = 10;
    private Collider leftFootCollider;
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            leftFootCollider.enabled = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //enemyに当たった時
        //if (collision.gameObject.layer == 10)
            if(other.CompareTag("Enemy"))
        {
            
            Debug.Log("hit");
            other.gameObject.GetComponent<Enemy_1>().onDamage(damage);
            //Destroy(this.gameObject);

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
