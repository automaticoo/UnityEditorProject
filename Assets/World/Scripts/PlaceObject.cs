using UnityEngine;
using System.Collections;
using System;

public class PlaceObject : MonoBehaviour {

    public GameObject DragObject;

	// Use this for initialization
	void Start () {
	    
	}


    public void DragGameObject(GameObject dragObject)
    {
        this.DragObject = dragObject;
    }

    public void StopDrag(bool destroy = false)
    {
        if (this.DragObject != null)
        {
            Destroy(this.DragObject);
        }
        this.DragObject = null;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (DragObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (GameObject.Find("Plane").collider.Raycast(ray, out hit, 1000))
            {
                Vector3 position = hit.point;
                position.x = (float)Math.Round((position.x+4) / 8) * 8;
                position.z = (float)Math.Round((position.z-4) / 8) * 8;

                DragObject.transform.position = position;
            }
            if (Input.GetMouseButtonDown(0))
            {
                DragObject = null;
            }
        }
	}
}
