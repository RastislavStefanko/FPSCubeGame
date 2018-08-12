using UnityEngine;

[CreateAssetMenu(menuName = "ModifiedAI/Actions/ChasePlayer")]
public class ChaseAction : Action {

    [SerializeField] private int speed = 4;
    [SerializeField] private int stoppingDistance = 2;

    public override void Act(StateController controller)
    {
        ChasePlayer(controller);
    }

    /// <summary>
    /// method for chasing player, simply navAgent trying to get to the player position
    /// </summary>
    /// <param name="controller"></param>
    private void ChasePlayer(StateController controller)
    {
        controller.navMeshAgent.speed = speed;
        controller.navMeshAgent.stoppingDistance = stoppingDistance;
        controller.navMeshAgent.destination = controller.gameController.player.position;
        controller.navMeshAgent.Resume();
    }
}
