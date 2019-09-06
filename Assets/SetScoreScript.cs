using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro meshPro;
    // Update is called once per frame
    void Update()
    {
        meshPro.text = GameSingleton.Instance.Score.ToString();
    }
}
