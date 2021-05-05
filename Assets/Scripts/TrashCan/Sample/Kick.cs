using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    Animator animator;
    //左足のコライダー
    private Collider leftFootCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        leftFootCollider = GameObject.Find("EthanLeftToe1").GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(leftFootCollider);
            animator.SetTrigger("Kick");
            //左足のコライダーをオンにする
            leftFootCollider.enabled = true;
            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 1.5f);
        }
    }

    private void ColliderReset()
    {
        leftFootCollider.enabled = false;
    }

}