using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private float timer, trigger;
    private void Start()
    {
        trigger = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.down * 0.05f * Time.deltaTime); 
        if(timer >= trigger)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
