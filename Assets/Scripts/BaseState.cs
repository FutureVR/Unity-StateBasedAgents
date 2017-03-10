using UnityEngine;
using System.Collections;

public class BaseState {

    public StateAgent agent;

    public BaseState(StateAgent stateAgent)
    {
        agent = stateAgent;
    }

    public virtual void exit() { }
    public virtual void enter() { }
    public virtual void update() { }

    public virtual void toState(BaseState bs)
    {
        agent.currState.exit();
        agent.currState = bs;
        agent.currState.enter();
    }
}
