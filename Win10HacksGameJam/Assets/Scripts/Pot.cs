using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour {

    public float RollSpeed = 10.0f;
    public float Speed = 8.0f;
    public AudioClip PotBreakSound;

    private Transform myTransform;

	// Use this for initialization
	void Start () 
    {
        this.myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.Instance.IsPaused) return;
        this.myTransform.Rotate(this.myTransform.forward, this.RollSpeed * Time.deltaTime);
        this.myTransform.position += Vector3.right * Speed * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Pig"))
        {
            col.gameObject.SendMessage("SmashPig");
            AudioSource.PlayClipAtPoint(this.PotBreakSound, Camera.main.transform.position, 0.4f);
            this.gameObject.SetActive(false);
        }
    }
}
