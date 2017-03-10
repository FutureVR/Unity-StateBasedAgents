using UnityEngine;
using System.Collections;

public class BuildHouse : BaseState
{

    public BuildHouse(StateAgent a) : base(a) { }

    public override void enter()
    {
        Debug.Log("Entering BuildHouse");
    }

    public override void update()
    {
        if (agent.totalWood > 0)
        {
            agent.home.wood += agent.collectionRate;
            agent.totalWood -= agent.collectionRate;
            agent.home.update();
        }
        else toState(agent.searchForWood);
    }

    public override void exit()
    {

    }
}
