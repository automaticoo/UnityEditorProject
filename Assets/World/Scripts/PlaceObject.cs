using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

    GameObject dragObject;

	// Use this for initialization
	void Start () {
	    
	}


    public void DragGameObject(GameObject dragObject)
    {
        this.dragObject = dragObject;
    }

    public void StopDrag(bool destroy = false)
    {
        if (this.dragObject != null)
        {
            Destroy(this.dragObject);
        }
        this.dragObject = null;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (dragObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (GameObject.Find("Plane").collider.Raycast(ray, out hit, 1000))
            {
                dragObject.transform.position = hit.point;
            }
        }
	}
}
