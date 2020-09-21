﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>
    public class PathFollower : MonoBehaviour
    {
        [SerializeField]
        [Range(0,100)]
        private float speed = 5;
        private Path path;
        void Start()
        {
            path = GetComponent<Path>();
            speed = Random.Range(10, 20);
        }
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, path.waypoints[path.arrayIndex].transform.position, speed * Time.deltaTime);
        }
    }
}