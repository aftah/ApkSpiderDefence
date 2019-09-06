using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;

public class shootScript : MonoBehaviour,ITrackableEventHandler
{

    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private int NumberOfBulletsInPool;
    private float timer, trigger;
    [SerializeField]
    private List<GameObject> Bullets = new List<GameObject>();
    [SerializeField]
    private TrackableBehaviour mTrackableBehaviour;
    private bool isDetected;
    public bool IsDetected { get; private set; }
    private GameObject b;
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

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0;i<NumberOfBulletsInPool;i++)
        {

            var b = Instantiate(Bullet);
            Bullets.Add(b);
            b.SetActive(false);
            b.transform.parent = gameObject.transform;
        }
        trigger = 0.65f;
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
        if(timer>= trigger)
        {
            try
            {
                timer = 0;
                GameObject bull = Bullets.Where(a => a.active == false).First();
                bull.transform.position = transform.position; // + new Vector3(0.45f, 2.5f, 0.3f);
                bull.transform.parent = transform;
                bull.SetActive(true);
                b = bull;
            }
            catch
            {
                timer = 0;
                var b1 = Instantiate(Bullet);
                b1.transform.parent = transform;
                b1.transform.position = transform.position;
                Bullets.Add(b1);
                b = b1;
            }
           
        }
    }
    public GameObject GetBulletToFollow()
    {
        return b;
    }
}
