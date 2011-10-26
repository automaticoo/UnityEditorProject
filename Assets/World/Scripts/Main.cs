using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;


public class Main : MonoBehaviour {
	
	GameObject block;

    DatabaseAcces databaseAcces;

    BlockData selected;

    List<BlockData> blockDatas;

    PlaceObject placeObjectScript;

	// Use this for initialization
	void Start () {

        databaseAcces = new DatabaseAcces();
        databaseAcces.OpenDatabase("collections.data");

        blockDatas = new List<BlockData>();

        SqliteDataReader reader = databaseAcces.ExecuteQuery("SELECT * FROM blocks");

        while (reader.Read())
        {
            blockDatas.Add(new BlockData(reader));
        }

        placeObjectScript = GetComponent<PlaceObject>();
        
	    /*block = (GameObject)Instantiate(Resources.Load("block1x1"), new Vector3(0,0,0), new Quaternion(0,0,0, 0));
		block.transform.Rotate(new Vector3(-90, 0, 0));
		block.transform.Translate(0,-8, 0);*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		int i;
        for (i = 0; i < blockDatas.Count; i++)
		{
            if (GUI.Toggle(new Rect(10, 10 + 25 * i, 100, 20), (selected != null && selected.ID == blockDatas[i].ID), blockDatas[i].File))
            {
                if (selected != blockDatas[i])
                {
                    if (placeObjectScript.DragObject)
                    {
                        placeObjectScript.StopDrag(true);
                    }

                    block = (GameObject)Instantiate(Resources.Load(blockDatas[i].File), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    block.transform.Rotate(new Vector3(-90, 0, 0));
                    placeObjectScript.DragGameObject(block);
                }

                selected = blockDatas[i];
            }
		}
        if (GUI.Button(new Rect(10, 10 + 25 * i, 100, 20), "unselect"))
        {
            selected = null;
            placeObjectScript.StopDrag(true);
        }
	}	
}
