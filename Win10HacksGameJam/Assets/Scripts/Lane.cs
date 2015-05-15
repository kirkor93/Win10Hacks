using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Lane : MonoBehaviour 
{
    public int LaneIndex = 0;

    private Collider2D myCollider = null;

	// Use this for initialization
	void Start () 
    {
        myCollider = this.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(0))
        {
            TryRaycast();
        }
	}

    private void TryRaycast()
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        if(hit != null && hit.collider != null)
        {
            if(hit.collider == this.myCollider)
            {
                //Spawn pot in my index
                Debug.Log("My index" + this.LaneIndex.ToString());
            }
        }
    }
}
