using UnityEngine;
using System.Collections;

public class Home {

    public GameObject building;
    float baseHeight = .2f;
    float heightFactor = .2f;
    public float wood;

    public Home(Vector3 pos)
    {
        building = GameObject.Instantiate(Resources.Load("House")) as GameObject;
        building.transform.position = pos;

        wood = 0;
        setHeight();
    }

    public void update()
    {
        setHeight();
    }

    public void setHeight()
    {
        float size_x = heightFactor * wood + baseHeight;
        float size_y = heightFactor * wood + baseHeight;
        float size_z = heightFactor * wood + baseHeight;
        building.transform.localScale = new Vector3(size_x, size_y, size_z);
    }

    public void gainWood(float amt)
    {
        wood += amt;
        Debug.Log(wood);
    }
}
