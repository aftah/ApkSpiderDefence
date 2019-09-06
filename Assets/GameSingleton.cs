using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance;

    //fields
    [SerializeField]
    private float score;

    //properties
    public float Score
    {
        get { return score; }
        set { score = value; }
    }



    //Functions

    private void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }



}
