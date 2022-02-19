using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BehaviorTree
{
    public sealed class GameWorld
    {
        public static GameWorld instance;
        List<GameObject> checkPoints = new List<GameObject>();
        public List<GameObject> CheckPoints { get { return checkPoints; } }

        public static GameWorld Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                    instance.CheckPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                    instance.checkPoints = instance.checkPoints.OrderBy(waypoint => waypoint.name).ToList();
                }
                return instance;
            }
        }
    }
}
