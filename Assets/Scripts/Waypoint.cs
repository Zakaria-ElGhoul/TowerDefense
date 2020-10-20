using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Waypoint : MonoBehaviour
{
    public Transform[] waypoints;

    private float speed = 5;
    public int arrayIndex = 0;
    public UnityEvent onFinalWaypointReached;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[arrayIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(waypoints[arrayIndex]);
        //Als de gameObject de positie bereikt. Dan gaat hij naar de volgende.
        if (transform.position == waypoints[arrayIndex].transform.position)
        {
            arrayIndex++;
        }

        //Als het gelijk staat met de lengte van de array. Dan gaat ie weer terug naar het begin.
        if(arrayIndex == waypoints.Length)
        {
            onFinalWaypointReached.Invoke();
        }
    }
}
