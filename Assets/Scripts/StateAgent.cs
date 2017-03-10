using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateAgent {

    public GameObject person;
    public NavMeshAgent navAgent;
    public Transform target;

    public float maxWood = 5;
    public float totalWood = 0;
    public float collectionRate = 1f * Time.deltaTime;

    public BaseState currState;
    public SearchForWood searchForWood;
    public CollectWood collectWood;
    public ReturnToHouse returnToHouse;
    public BuildHouse buildHouse;

    public List<WoodPile> woodPiles;
    public List<Home> homes;

    public WoodPile closestWoodPile;
    public Home home;


    public StateAgent(Vector3 pos, List<WoodPile> wps, List<Home> hs)
    {
        person = GameObject.Instantiate(Resources.Load("Person")) as GameObject;
        //home = new Home(pos);
        person.transform.position = pos;
        navAgent = person.GetComponent<NavMeshAgent>();

        woodPiles = wps;
        homes = hs;
        chooseHouse();

        searchForWood = new SearchForWood(this);
        collectWood = new CollectWood(this);
        returnToHouse = new ReturnToHouse(this);
        buildHouse = new BuildHouse(this);

        currState = searchForWood;
        currState.enter();
    }

    public void chooseHouse()
    {
        home = homes[Random.Range(0, homes.Count - 1)];
    }

    public void update()
    {
        currState.update(); //Ignore this error until this function is implemented
    }
}
