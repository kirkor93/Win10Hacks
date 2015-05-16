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
    public GameObject SuperPigPrefab;
    public GameObject HeavyPigPrefab;
    public GameObject InstantPigPrefab;
    public float LaneHeight = 3.33f;
    public int StartPigCount = 5;
    public GameObject LaneBegin;

    private List<GameObject> allPigs = new List<GameObject>();
    private List<GameObject> allSuperPigs = new List<GameObject>();
    private List<GameObject> allHeavyPigs = new List<GameObject>();
    private List<GameObject> allInstantPigs = new List<GameObject>();

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
        for (int i = 0; i < this.StartPigCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.SuperPigPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allSuperPigs.Add(go);
        }
        for (int i = 0; i < this.StartPigCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.HeavyPigPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allHeavyPigs.Add(go);
        }
        for (int i = 0; i < this.StartPigCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.InstantPigPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allInstantPigs.Add(go);
        }
        GameManager.Instance.OnReset += Reset;
	}

    public void SpawnPig(int laneIndex)
    {
        System.Random rnd = new System.Random();
        double r = rnd.NextDouble();
        if(r > 0.8f)
        {
            SpawnHeavyPig(laneIndex);
        }
        else if(r > 0.6f)
        {
            SpawnSuperPig(laneIndex);
        }
        else if(r > 0.4f)
        {
            SpawnInstantPig(laneIndex);
        }
        else
        {
            SpawnNormalPig(laneIndex);
        }
    }

    private void SpawnInstantPig(int laneIndex)
    {
        foreach (GameObject go in allInstantPigs)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                go.GetComponent<InstantPig>().MyLane = laneIndex;
                go.GetComponent<InstantPig>().OnSpawn();
                return;
            }
        }

        GameObject pig = GameObject.Instantiate(InstantPigPrefab, new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pig.transform.parent = this.transform;
        pig.GetComponent<InstantPig>().MyLane = laneIndex;
        pig.GetComponent<InstantPig>().OnSpawn();
        this.allInstantPigs.Add(pig);
    }

    private void SpawnNormalPig(int laneIndex)
    {
        foreach (GameObject go in allPigs)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                return;
            }
        }

        GameObject pig = GameObject.Instantiate(PigPrefab, new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pig.transform.parent = this.transform;
        this.allPigs.Add(pig);
    }

    private void SpawnSuperPig(int laneIndex)
    {
        foreach (GameObject go in allSuperPigs)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                return;
            }
        }

        GameObject pig = GameObject.Instantiate(SuperPigPrefab, new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pig.transform.parent = this.transform;
        this.allSuperPigs.Add(pig);
    }

    private void SpawnHeavyPig(int laneIndex)
    {
        foreach (GameObject go in allHeavyPigs)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                return;
            }
        }

        GameObject pig = GameObject.Instantiate(HeavyPigPrefab, new Vector3(this.LaneBegin.transform.position.x, 4.3f - laneIndex * LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pig.transform.parent = this.transform;
        this.allHeavyPigs.Add(pig);
    }

    void Reset()
    {
        foreach(GameObject go in this.allPigs)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in this.allHeavyPigs)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in this.allInstantPigs)
        {
            go.SetActive(false);
        }
        foreach(GameObject go in this.allSuperPigs)
        {
            go.SetActive(false);
        }
    }
}
