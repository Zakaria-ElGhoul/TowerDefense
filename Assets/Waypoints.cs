using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De waypoint class beheerd een punt in de wereld. Welke je kunt opvragen
    /// Voor de opdracht is deze class al klaar en hoeft hier niets te gebeuren.
    /// </summary>
    public class Waypoints : MonoBehaviour
    {
        public Vector3 Position { get { return transform.position; } }
    }
}