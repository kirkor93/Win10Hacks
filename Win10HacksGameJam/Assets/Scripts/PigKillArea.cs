using UnityEngine;
using System.Collections;

public class PigKillArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(LayerMask.LayerToName(col.gameObject.layer));
        if(col.gameObject.layer == LayerMask.NameToLayer("Pig"))
        {
            col.SendMessage("Kill", SendMessageOptions.DontRequireReceiver);
        }
    }
}
