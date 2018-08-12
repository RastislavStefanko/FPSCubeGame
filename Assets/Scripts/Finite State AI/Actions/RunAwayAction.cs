using UnityEngine;

[CreateAssetMenu(menuName = "ModifiedAI/Actions/RunAway")]
public class RunAwayAction : Action {

    [SerializeField] private int speed = 4;

    public override void Act(StateController controller)
    {
        RunAway(controller);
    }

    /// <summary>
    /// method for running away from player, computes direction away from player
    /// </summary>
    /// <param name="controller"></param>
    private void RunAway(StateController controller)
    {
        controller.navMeshAgent.speed = speed;
        controller.navMeshAgent.destination = (controller.transform.position 
            - controller.gameController.player.position).normalized * 50;
        controller.navMeshAgent.Resume();
    }
}
