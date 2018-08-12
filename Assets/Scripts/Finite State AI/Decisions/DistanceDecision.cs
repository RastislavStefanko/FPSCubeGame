using UnityEngine;

[CreateAssetMenu(menuName = "ModifiedAI/Decisions/DistDecision")]
public class DistanceDecision : Decision {

    public override bool Decide(StateController controller)
    {
        return DistanceFromPlayer(controller);
    }

    /// <summary>
    /// return true if distance from player is lower or equal than 10m
    /// </summary>
    /// <param name="controller"></param>
    /// <returns> true if distance is lower or equal than 10m </returns>
    private bool DistanceFromPlayer(StateController controller)
    {
        if(Vector3.Distance(controller.transform.position, controller.gameController.player.position) <= 10)
        {
            return true;
        }

        return false;
    }
}
