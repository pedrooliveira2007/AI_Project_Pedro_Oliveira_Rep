using UnityEngine;
using System.Collections;
using LibGameAI.DecisionTrees;

public class AIDecisionTree : MonoBehaviour
{
    [SerializeField]
    private int randomDecisionDurationInFrames = 240;

    // References the player
    private Pawn_Manager pawn;


    // The root of the decision tree
    private IDecisionTreeNode root;

    // Create the decision tree
    protected void Start()
    {
        pawn = GetComponent<Pawn_Manager>();

        // Create the leaf actions
        IDecisionTreeNode fleeToExit = new ActionNode(pawn.fleeToExitAction);
        IDecisionTreeNode goEat = new ActionNode(pawn.goEatAction);
        IDecisionTreeNode goToConcert = new ActionNode(pawn.goConcertAction);
        IDecisionTreeNode goRest = new ActionNode(pawn.RestAction);
        IDecisionTreeNode nothing = new ActionNode(pawn.Nothing);


        // Create the random decision behaviour node
        RandomDecisionBehaviour rdb = new RandomDecisionBehaviour(
            () => Random.value,
            () => Time.frameCount,
            randomDecisionDurationInFrames,
            0.55f);

        //Create nodes

        IDecisionTreeNode isTired = new DecisionNode(pawn.isTired, goRest, goToConcert);
        IDecisionTreeNode isHungry = new DecisionNode(pawn.isHungry, goEat, isTired);
        IDecisionTreeNode isSubscribed = new DecisionNode(pawn.isSubscribed, nothing, isHungry);
        root = new DecisionNode(pawn.isInPanic, fleeToExit, isHungry);


    }

    // Run the decision tree and execute the returned action
    private void FixedUpdate()
    {
        if(!pawn.isEating() && !pawn.isResting() && pawn.GetGoal() != 3 && pawn.GetGoal() != 4)
        {
            ActionNode actionNode = root.MakeDecision() as ActionNode;
            actionNode.Execute();
        }
    }


}