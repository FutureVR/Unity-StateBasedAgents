using UnityEngine;
using System.Collections;

public class SearchForWood : BaseState {

    WoodPile closestPile;
    float woodRadius = 1;

    public SearchForWood(StateAgent a) : base(a)
    {
        //closestPile = agent.woodPiles[0];
    }


    public override void enter()
    {
        Debug.Log("Entering SearchForWood");
        //Find the closest woodPile
        closestPile = agent.woodPiles[0];
        float closestDist = Vector3.Distance(agent.woodPiles[0].wood.transform.position, agent.person.transform.position);
        foreach(WoodPile wp in agent.woodPiles)
        {
            if (wp.dead == false)
            {
                float dist = Vector3.Distance(wp.wood.transform.position, agent.person.transform.position);
                if (dist < closestDist)
                {
                    closestPile = wp;
                    closestDist = dist;
                }
            }
        }

        agent.navAgent.destination = closestPile.wood.transform.position;
        agent.closestWoodPile = closestPile;
    }

    public override void update()
    {
        //Debug.Log("Searching For Wood");
        if (Vector3.Distance(agent.person.transform.position, closestPile.wood.transform.position) < woodRadius)
            toState(agent.collectWood);
    }

    public override void exit()
    {
        Debug.Log("Exiting SearchForWood");
    }
}
