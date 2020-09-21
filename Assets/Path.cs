﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Opdrachten
{
    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {
        public Transform[] waypoints;
        public int arrayIndex = 0;
        public UnityEvent onFinalWaypointReached;

        void Start()
        {
            Waypoints wp = GetComponent<Waypoints>();
        }

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        void Update()
        {
            GetNextWaypoint();
        }

        public Waypoints GetNextWaypoint()
        {
            //Als de gameObject de positie bereikt. Dan gaat hij naar de volgende.
            if (transform.position == waypoints[arrayIndex].transform.position)
            {
                arrayIndex++;
            }

            //Als het gelijk staat met de lengte van de array. Dan gaat ie weer terug naar het begin.
            if (arrayIndex == waypoints.Length)
            {
                onFinalWaypointReached.Invoke();
                DestroyImmediate(this.gameObject);
            }
            return null;
        }
    }
}
