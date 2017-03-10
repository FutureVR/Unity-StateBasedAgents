using UnityEngine;
using System.Collections;

public class CollectWood : BaseState
{
    public CollectWood(StateAgent a) : base(a) { }

    public override void enter()
    {
        Debug.Log("Entering CollectWood");
    }

    public override void update()
    {
        if(agent.totalWood < agent.maxWood  &&  agent.closestWoodPile.logAmt > 0)
        {
            agent.closestWoodPile.loseLogs(agent.collectionRate);
            agent.totalWood += agent.collectionRate;
            agent.closestWoodPile.update();
        }
        else toState(agent.returnToHouse);
    }

    public override void exit()
    {
        Debug.Log("Exiting CollectWood");
    }
}
