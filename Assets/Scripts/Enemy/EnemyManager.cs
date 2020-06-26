using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(target.position);
        //Debug.Log(agent.destination);
        agent.destination = target.position;
        //Debug.Log(target.position);
        //Debug.Log(agent.destination);
    }
}
