using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestGeneration : MonoBehaviour {
	public List<BSP> leaf = new List<BSP>();
	public List<Rect> rooms = new List<Rect>();
	public List<Rect> halls = new List<Rect>();
	public GameObject[,] go = new GameObject[100,100];
	public GameObject floor;
	
	
	public GameObject wall;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 100; j++){
				var t1 = (GameObject)Instantiate (wall, new Vector2 (i, j), Quaternion.identity);
				t1.transform.parent = GameObject.Find ("One").transform;
				t1.isStatic = true;
				go[i,j] = t1;
			}
		}
		var root = new BSP (0, 0, 100, 100);
		leaf.Add (root);
		var didsplit = true;
		while (didsplit) {
			didsplit = false;
			foreach (BSP l in leaf.ToArray()) {
				if (l.leftChild == null && l.rightChild == null) {
					if (l.width > 20 || l.height > 20 || Random.value > 0.25f) {
						if (l.Split ()) {
							leaf.Add (l.leftChild);
							leaf.Add (l.rightChild);
							didsplit = true;
						}
					}
				}
			}
		}
		
		root.CreateRooms ();
		
		foreach (BSP l in leaf) {
			if (l.room != null) {
				
				rooms.Add (l.room);
				
			}
			if (l.halls != null && l.halls.Count > 0)
			{
				foreach(Rect r in l.halls)
				{
					halls.Add(r);
				}
			}
		}
		
		foreach (Rect r in rooms) {
			for (int i = (int)r.x; i < (int)(r.x + r.width); i++) {
				for (int j = (int)r.y; j < (int)(r.y + r.height); j++) {
					if (i == (int)r.x || i == (int)(r.width + r.x - 1) || j == (int)r.y || j == ((int)r.y + (int)r.height - 1)) {
						Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),new Vector3((int)r.center.x,(int)r.center.y,4),Quaternion.identity);
						var t2 = (GameObject)Instantiate (wall, new Vector2 (i, j), Quaternion.identity);
						t2.transform.parent = GameObject.Find ("Two").transform;
						t2.transform.localScale = new Vector3 (.7f, .7f, 0);
						var t3 = (GameObject)Instantiate (wall, new Vector2 (i, j), Quaternion.identity);
						t3.transform.parent = GameObject.Find ("Three").transform;
						t3.transform.localScale = new Vector3 (.5f, .5f, 0);
						var t4 = (GameObject)Instantiate (wall, new Vector2 (i, j), Quaternion.identity);
						t4.transform.parent = GameObject.Find ("Four").transform;
						t4.transform.localScale = new Vector3 (.3f, .3f, 0);
					}
					else {

						Destroy(go[i,j].gameObject);
						var ground =  (GameObject) Instantiate(floor,new Vector3(i,j,3),Quaternion.identity);
						ground.transform.parent = GameObject.Find("Ground").transform;
					}
					
					
				}
				
			}
			
		}

			

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
