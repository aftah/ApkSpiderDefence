using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float timer;
    private float timeToDestroy = 4f;
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * 5f*Time.deltaTime);
        if(timer > timeToDestroy)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
