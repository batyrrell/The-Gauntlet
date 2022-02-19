using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class State
{

    
    public enum STATE
    { 
        IDLE, PATROL, PURSUE, WANDER, RUNAWAY
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Transform player;
    protected NavMeshAgent agent;
    protected State nextState;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float backDist = 2.0f;

    public static int debugIdle = 0;
    public static int debugPatrol = 0;
    public static int debugPursue = 0;
    public static int debugWander = 0;
    public static int debugRun = 0;

    public State(GameObject _npc, NavMeshAgent _agent, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        stage = EVENT.ENTER;
        player = _player;
    }

    //POLYMORPHISM

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle)
            return true;
        return false;
    }

    public bool Spooked()
    {
        Vector3 direction = npc.transform.position - player.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < backDist && angle < visAngle)
            return true;
        return false;
    }

    public void PrintDebug()
    {
        Debug.Log("Idle: " + debugIdle);
        Debug.Log("Patrol: " + debugPatrol);
        Debug.Log("Pursue: " + debugPursue);
        Debug.Log("Wander: " + debugWander);
        Debug.Log("Run: " + debugRun);
    }
}
