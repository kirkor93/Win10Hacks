using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PigPool : MonoBehaviour {

    private static PigPool instance;

    public static PigPool Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PigPool>();
                if(instance == null)
                {
                    Debug.LogError("There is no pig pool");
                }
            }
            return instance;
        }
    }

    public GameObject PigPrefab;
    public float LaneHeight = 3.33f;
    public int StartPigCount = 5;
    public GameObject LaneBegin;

    private List<GameObject> allPigs = new List<GameObject>();

	// Use this for initialization
	void Start () 
    {
	    for(int i = 0; i < this.StartPigCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.PigPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allPigs.Add(go);
        }
        GameManager.Instance.OnReset += Reset;
	}

    public void SpawnPig(int laneIndex)
    {
        foreach(GameObject go in allPigs)
        {
            if(!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(this.LaneBegin.transform.position.x, 3.33f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                return;
            }
        }

        GameObject pig = GameObject.Instantiate(PigPrefab, new Vector3(this.LaneBegin.transform.position.x, 3.33f - laneIndex * LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pig.transform.parent = this.transform;
        this.allPigs.Add(pig);
    }

    void Reset()
    {
        foreach(GameObject go in this.allPigs)
        {
            go.SetActive(false);
        }
    }
}
