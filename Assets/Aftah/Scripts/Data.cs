using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Data : MonoBehaviour
{
    public static Data instanceData;

    public List<Transform> listGatePosition;
   

    private void Awake()
    {
        if (instanceData != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceData = this;
        }

       
    }

}
