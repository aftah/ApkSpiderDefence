using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private List<Transform> listGate;
    [SerializeField] private int enemyCount;
    [SerializeField] private float timeToWait;


    private Transform enemyToGate; 

    private void Start()
    {

        Invoke("SpawnEnemy", timeToWait);
       
    }

   

    private void SpawnEnemy()
    {
        GameObject objEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);

        enemyToGate = listGate [Random.Range(0, listGate.Count - 1)];
        objEnemy.GetComponent<MoveEnemyToTarget>().gate = enemyToGate;
        Invoke("SpawnEnemy", Random.Range(timeToWait,5));
    }
}
