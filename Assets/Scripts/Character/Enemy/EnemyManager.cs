using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{

    //プレイヤーを追うスクリプト
    NavMeshAgent agent;
    //public Transform target;
    GameObject target;
    private AudioSource Walk;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("t-800_LP").transform;
        //target = GameObject.Find("pepper Variant Variant Variant Variant").transform;

        //target = GameObject.FindGameObjectsWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        Walk = gameObject.GetComponent<AudioSource>();
        //GundamWalk.clip = audioClip1;
        Walk.Play();
        //GundamWalk =　AudioSource.
        //agent.destination = target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(target.position);
        //Debug.Log(agent.destination);
        //GameObject target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        //Debug.Log(agent);
        //Debug.Log(target);
        if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //navMeshAgentの操作
            agent.destination = target.transform.position;
            //GundamWalk.Play();
            //Debug.Log("agent");

        }
        //Debug.Log(target.position);
        //Debug.Log(agent.destination);
    }
}
