using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameWorld
{
    public static GameWorld instance;
    List<GameObject> checkPoints = new List<GameObject>();
    public List<GameObject> CheckPoints { get { return checkPoints; } }
    public GameObject safeSpot;

    public static GameWorld Singleton
    {
        get
        {
            if(instance==null)
            {
                instance = new GameWorld();
                instance.CheckPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                instance.checkPoints = instance.checkPoints.OrderBy(waypoint => waypoint.name).ToList();
                instance.safeSpot = GameObject.FindGameObjectWithTag("Safespot");
            }
            return instance;
        }
    }
}
