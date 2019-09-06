using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
public class spawnscript : MonoBehaviour,ITrackableEventHandler
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float ammountOfTime,NumberOfEnemiesInPool;
    [SerializeField]
    private List<Transform> listGate;
    private bool IsDetected;
    private float timer;
    private List<GameObject> gameObjects;
    [SerializeField]
    private TrackableBehaviour mTrackableBehaviour;
    public GameObject b;

    private Transform enemyToGate;

    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new List<GameObject>();
        for(var i = 0; i < NumberOfEnemiesInPool; i++)
        {
            var a = Instantiate(prefab);
            //a.transform.parent = transform;
            gameObjects.Add(a);
            a.SetActive(false);
            //a.transform.position = transform.position;
        }

        mTrackableBehaviour = GetComponentInParent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= ammountOfTime && IsDetected)
        {
            timer = 0;
            SpawnEnemyFromPool();
        }
    }

    private void SpawnEnemyFromPool()
    {
        try
        {
            GameObject ob = gameObjects.Where(a => a.active == false).First();
            ob.SetActive(true);
            enemyToGate = listGate[Random.Range(0, listGate.Count - 1)];
           
            ob.GetComponentInChildren<MoveEnemyToTarget>().gate = enemyToGate.transform ;
            ob.transform.position = this.transform.position;
            
            b = ob;
        }
        catch
        { 
            GameObject no = Instantiate(prefab);
            no.transform.parent = transform;
            gameObjects.Add(no);
            b = no;
        }
      
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
           newStatus == TrackableBehaviour.Status.TRACKED ||
           newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            IsDetected = true;
            Debug.Log("image detected");
        }
      
    }
    public GameObject GetEnemyToFollow()
    {
        return b;
    }
}
