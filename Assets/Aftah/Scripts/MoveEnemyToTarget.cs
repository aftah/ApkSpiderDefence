using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveEnemyToTarget : MonoBehaviour
{
    

    public Transform gate;
 
    private NavMeshAgent agent;


    private void Start()
    {
       
        StartCoroutine(enumerator());
    }


    IEnumerator enumerator()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(gate.transform.position);
        Debug.Log("Navmesh position = " + gate.transform.position);

        yield return new WaitForSeconds(3);
    }

}
