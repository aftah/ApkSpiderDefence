using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCube : MonoBehaviour
{
    
    public Transform target;
    [SerializeField]
    private GameObject bullet;
    void Update()
    {
        try
        {
            target = bullet.GetComponent<spawnscript>().GetEnemyToFollow().transform;
            // Rotate the camera every frame so it keeps looking at the target
            Quaternion rotation = Quaternion.LookRotation(target.position, Vector3.up);
            transform.LookAt(target);
        }
        catch { }
    }
}
