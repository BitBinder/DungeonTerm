using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestGeneration : MonoBehaviour {
    public List<BSP> leaf = new List<BSP>();


    public GameObject wall;
	// Use this for initialization
	void Start () {

        var root = new BSP(0, 0, 20, 20);
        leaf.Add(root);
        var didsplit = true;
        while (didsplit)
        {
            didsplit = false;
            foreach (BSP l in leaf.ToArray())
            {
                if (l.leftChild == null && l.rightChild == null)
                {
                    if (l.width > 5 || l.height > 5 || Random.value > 0.25f)
                    {
                        if (l.Split())
                        {
                            leaf.Add(l.leftChild);
                            leaf.Add(l.rightChild);
                            didsplit = true;
                        }
                    }
                }
            }
        }

        root.CreateRooms();

        foreach (BSP l in leaf)
        {
            if (l.room != null)
            {
                //draw
                for (int i = (int)l.room.x; i < l.room.x + l.room.width; i++)
                {
                    for (int j = (int)l.room.y; j < l.room.y + l.room.height; j++)
                    {
                       
                            var t1 =(GameObject)Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                            t1.transform.parent = GameObject.Find("One").transform;
                            var t2 = (GameObject)Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                            t2.transform.parent = GameObject.Find("Two").transform;
                            t2.transform.localScale = new Vector3(.7f, .7f, 0);
                            var t3 = (GameObject)Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                            t3.transform.parent = GameObject.Find("Three").transform;
                            t3.transform.localScale = new Vector3(.5f, .5f, 0);
                            var t4 = (GameObject)Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                            t4.transform.parent = GameObject.Find("Four").transform;
                            t4.transform.localScale = new Vector3(.3f, .3f, 0);

                     
                    }
                }
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
