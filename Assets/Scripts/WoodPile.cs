using UnityEngine;
using System.Collections;

public class WoodPile {

    public GameObject wood;
    public float logAmt;
    public bool dead = false;

    float baseHeight = .0f;
    float heightFactor = .2f;

	public WoodPile (Vector3 pos, float log)
    {
        wood = GameObject.Instantiate(Resources.Load("Wood")) as GameObject;
        wood.transform.position = pos;
        logAmt = log;

        setHeight();
	}

    public void update()
    {
        if (logAmt <= .1) dead = true;

        setHeight();
    }

    public void setHeight()
    {
        float size_x = wood.transform.localScale.x;
        float size_y = heightFactor * logAmt + baseHeight;
        float size_z = wood.transform.localScale.z;
        wood.transform.localScale = new Vector3(size_x, size_y, size_z);
    }

    public void loseLogs(float amt)
    {
        logAmt -= amt;
    }

    public void kill()
    {
        //Destroy(this);
    }
}
