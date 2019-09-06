using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CollisionScript : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> Enemies;
    private GameObject tempEnemy;
    [SerializeField]
    private GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<GameObject>();
    }
   

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (tempEnemy = null)
            {
                tempEnemy = GetEnemyToShoot();
            }

           turret.transform.LookAt(tempEnemy.transform);
            Debug.Log(turret.transform.rotation);
        }
        catch
        {
            //transform.LookAt(Vector3.forward);
        }
    }
    private GameObject GetEnemyToShoot()
    {
        GameObject ob = Enemies.Where(a => a.active).First();
        Debug.Log(ob);
        return ob;
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Enemies.Add(collision.gameObject);
        Debug.Log("get enemy");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemies.Add(collision.gameObject);
        Debug.Log("get enemy");
    }
    private void OnTriggerExit(Collider collision)
    {
        Enemies.Remove(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        Enemies.Remove(collision.gameObject);
        Debug.Log("Exit collision");
    }




}
