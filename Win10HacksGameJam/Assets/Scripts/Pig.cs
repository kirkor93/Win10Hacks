using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour {

    public float Speed = 3.0f;
    public GameObject BurgerPrefab;

    private Transform myTransform;

	// Use this for initialization
	void Start () 
    {
        this.myTransform = this.GetComponent<Transform>();	
  	}
	
	// Update is called once per frame
	void Update () 
    {
        this.myTransform.Translate(Vector3.left * Speed * Time.deltaTime);
	}

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

    void SmashPig()
    {
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        this.gameObject.SetActive(false);
    }
}
