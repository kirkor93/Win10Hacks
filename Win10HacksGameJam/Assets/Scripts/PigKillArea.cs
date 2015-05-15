﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PigKillArea : MonoBehaviour {

    public int HP = 10;
    public int FirstDestroyLevel = 7;
    public int SecondDestroyLevel = 3;

    public Transform Min;
    public Transform Max;
    public GameObject FirePrefab;

    private float xDifference;
    private float yDifference;
    private bool firstDestroyLevelReached;
    private bool secondDestroyLevelReached;

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
        }
        else if(!secondDestroyLevelReached && HP < this.SecondDestroyLevel)
        {
            secondDestroyLevelReached = true;
            SpawnParticles();
        }
        else if(!firstDestroyLevelReached && HP < this.FirstDestroyLevel)
        {
            SpawnParticles();
            firstDestroyLevelReached = true;
        }
    }

    void SpawnParticles()
    {
        System.Random rnd = new System.Random();
        for(int i = 0; i < 3; ++i)
        {
            float x = (float)rnd.NextDouble() * xDifference + Min.position.x;
            float y = (float)rnd.NextDouble() * yDifference + Min.position.y;
            GameObject go = Instantiate(this.FirePrefab, new Vector3(x, y, 10.0f), Quaternion.identity) as GameObject;
            this.particles.Add(go);
        }
    }

    void Reset()
    {
        this.HP = 10;
        foreach(GameObject p in this.particles)
        {
            Destroy(p);
        }
    }
}
