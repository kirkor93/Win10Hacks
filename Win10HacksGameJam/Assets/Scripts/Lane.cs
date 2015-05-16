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
        if (GameManager.Instance.IsPaused) return;
	    if(Input.GetMouseButtonDown(0))
        {
            TryRaycast(Input.mousePosition);
        }
        if(Input.touchCount > 0)
        {
            foreach(Touch t in Input.touches)
            {
                if (t.phase != TouchPhase.Began) return;
                TryRaycast(t.position);
            }
        }
	}

    private void TryRaycast(Vector3 screenPoint)
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        int mask = ~(1 << 8);
        hit = Physics2D.Raycast(ray.origin, ray.direction,float.MaxValue,mask);
        if(hit != null && hit.collider != null)
        {
            if(hit.collider == this.myCollider)
            {
                if(RightPanelController.instance.GetPotToThrow())
                {
                    PotPool.Instance.SpawnPot(this.LaneIndex);
                }
            }
        }
    }
}
