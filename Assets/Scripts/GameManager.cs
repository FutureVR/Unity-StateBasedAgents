using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject terrain;
    public float terrainWidth = 10;
    public float terrainLength = 10;


    List<StateAgent> stateAgents = new List<StateAgent>();
    public int numOfAgents = 1;
    public float agentDistMultiplier = 3;

    List<WoodPile> woodPiles = new List<WoodPile>();
    public float pileDistMultiplier = 3;
    public int numOfPiles = 10;
    public float minLogAmt = 1;
    public float maxLogAmt = 2;

    List<Home> homes = new List<Home>();
    public int numOfHomes = 5;

	void Start ()
    {
        //Instantiate(terrain, new Vector3(0, 0, 0), Quaternion.identity);
        createWoodPiles(numOfPiles);
        createHomes(numOfHomes);
        createStateAgents(numOfAgents);

        //foreach (StateAgent sa in stateAgents) sa.currState.enter();
    }
	

	void Update ()
    {
        foreach (StateAgent sa in stateAgents) sa.update();
        for (int i = 0; i < woodPiles.Count; i++)
        {
            if (woodPiles[i].dead == true)
            {
                WoodPile garbage = woodPiles[i];
                woodPiles.RemoveAt(i);
                //garbage.kill();
            }
            
        }
        //foreach (WoodPile wp in woodPiles) wp.update();
        //foreach (Home h in homes) h.update();
	}

    //Creates a list of woodPiles and placing them on the terrain
    void createWoodPiles(int NumOfWoodPiles)
    {
        for (int i = 0; i < NumOfWoodPiles; i++)
        {
            float x = pileDistMultiplier * Random.Range(-terrainLength, terrainLength);
            float z = pileDistMultiplier * Random.Range(-terrainWidth, terrainWidth);
            float logAmt = Random.Range(minLogAmt, maxLogAmt);

            WoodPile wp = new WoodPile(new Vector3(x, 0.5f, z), logAmt); //Change y in vector3 to make sure the bottom of pile is on the terrain
            woodPiles.Add(wp);
        }
    }

    void createStateAgents(int agents) //Implement this function fuller
    {
        for (int i = 0; i < numOfAgents; i++)
        {
            float x = agentDistMultiplier * Random.Range(-terrainLength, terrainLength);
            float z = agentDistMultiplier * Random.Range(-terrainWidth, terrainWidth);

            StateAgent sa = new StateAgent(new Vector3(x, 0, z), woodPiles, homes);
            stateAgents.Add(sa);
        }
    }

    void createHomes(int homeNum)
    {
        for (int i = 0; i < homeNum; i++)
        {
            float x = agentDistMultiplier * Random.Range(-terrainLength, terrainLength);
            float z = agentDistMultiplier * Random.Range(-terrainWidth, terrainWidth);

            Home h = new Home(new Vector3(x, 0, z));
            homes.Add(h);
        }
    }
}
