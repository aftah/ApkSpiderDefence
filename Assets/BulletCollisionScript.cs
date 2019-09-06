using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            // add score here!!!!
            GameSingleton.Instance.Score += 10;
    }

}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            // add score here!!!!
            GameSingleton.Instance.Score += 10;
        }
    }

}
