using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PigKillArea : MonoBehaviour {

    public int HP = 10;

    public Transform Min;
    public Transform Max;
    public GameObject FirePrefab;
    public AudioSource FireSound;

    private float xDifference;
    private float yDifference;

    private List<GameObject> particles = new List<GameObject>();

	// Use this for initialization
	void Start () {
        xDifference = Max.position.x - Min.position.x;
        yDifference = Max.position.y - Min.position.y;
        GameManager.Instance.OnReset += Reset;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.Instance.IsPaused) return;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Pig"))
        {
            col.SendMessage("Kill", SendMessageOptions.DontRequireReceiver);
            HPDecrease();
        }
    }

    void HPDecrease()
    {
        --HP;
        if(HP < 0)
        {
            GameManager.Instance.GameOver();
            return;
        }
        SpawnParticles();
    }

    void SpawnParticles()
    {
        System.Random rnd = new System.Random();
        float x = (float)rnd.NextDouble() * xDifference + Min.position.x;
        float y = (float)rnd.NextDouble() * yDifference + Min.position.y;
        GameObject go = Instantiate(this.FirePrefab, new Vector3(x, y, 10.0f), Quaternion.identity) as GameObject;
        this.particles.Add(go);
        FireSound.volume += 0.1f;
    }

    void Reset()
    {
        this.HP = 10;
        FireSound.volume = 0.0f;
        foreach(GameObject p in this.particles)
        {
            Destroy(p);
        }
    }
}
