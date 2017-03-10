using UnityEngine;
using System.Collections;

public class ReturnToHouse : BaseState
{
    float houseRadius = 4;

    public ReturnToHouse(StateAgent a) : base(a) { }

    public override void enter()
    {
        Debug.Log("Entering ReturnToHouse");
        agent.navAgent.destination = agent.home.building.transform.position;
    }

    public override void update()
    {
        if (Vector3.Distance(agent.navAgent.destination, agent.person.transform.position) < houseRadius)
            toState(agent.buildHouse);
    }

    public override void exit()
    {
        Debug.Log("Exiting ReturnToHouse");
    }
}
