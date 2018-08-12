using UnityEngine;

[CreateAssetMenu(menuName = "ModifiedAI/Actions/Patrol")]
public class PatrolAction : Action
{
    [SerializeField] private int speed = 2;
    [SerializeField] private int stoppingDistance = 10;

    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    /// <summary>
    /// patroling around waypoints selected in gameController
    /// </summary>
    /// <param name="controller"></param>
    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.speed = speed;
        controller.navMeshAgent.stoppingDistance = stoppingDistance;
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.Resume();

        //check if navAgent is at current waypoint and random selecting new waypoint
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = Random.Range(0, controller.wayPointList.Count);
        }
    }
}