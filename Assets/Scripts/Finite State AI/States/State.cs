using UnityEngine;

[CreateAssetMenu(menuName = "ModifiedAI/State")]
public class State : ScriptableObject {

    [SerializeField] private Action action;
    [SerializeField] private Transition transition;

    /// <summary>
    /// update state method calling every frame
    /// </summary>
    /// <param name="controller"></param>
    public void UpdateState(StateController controller)
    {
        action.Act(controller);
        CheckTransitions(controller);
    }

    /// <summary>
    /// check every frame if decision is true
    /// </summary>
    /// <param name="controller"></param>
    private void CheckTransitions(StateController controller)
    {

            bool decisionSucceeded = transition.decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transition.trueState);
            }
            else
            {
                controller.TransitionToState(transition.falseState);
            }
        
    }
}
