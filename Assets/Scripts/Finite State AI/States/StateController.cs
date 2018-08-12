using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour
{
    [SerializeField] private State currentState;
    [SerializeField] private State remainState;

    [HideInInspector] public GameController gameController => GameController.Instance;
    [HideInInspector] public NavMeshAgent navMeshAgent { get; set; }
    [HideInInspector] public List<Transform> wayPointList { get; set; }
    [HideInInspector] public int nextWayPoint { get; set; }

    void Start()
    {
        wayPointList = gameController.wayPoints;
        nextWayPoint = Random.Range(0, wayPointList.Count);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    /// <summary>
    /// change state to next
    /// </summary>
    /// <param name="nextState"></param>
    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}