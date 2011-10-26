using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour {
	
	GameObject block;

    DatabaseAcces databaseAcces;

	// Use this for initialization
	void Start () {

        databaseAcces = new DatabaseAcces();
        databaseAcces.OpenDatabase("collections.data");
        Debug.Log(databaseAcces.ReadFullTable("blocks"));

		block = (GameObject)Instantiate(Resources.Load("block1x1"), new Vector3(0,0,0), new Quaternion(0,0,0, 0));
		block.transform.Rotate(new Vector3(-90, 0, 0));
		block.transform.Translate(0,-8, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		 
	}	
}
