using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PotPool : MonoBehaviour {

    private static PotPool instance;

    public static PotPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PotPool>();
                if (instance == null)
                {
                    Debug.LogError("There is no pig pool");
                }
            }
            return instance;
        }
    }

    public GameObject PotPrefab;
    public float LaneHeight = 3.33f;
    public int StartPotCount = 5;
    public GameObject LaneLeftEnd;

    private List<GameObject> allPots = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < this.StartPotCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.PotPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allPots.Add(go);
        }
    }

    public void SpawnPot(int laneIndex)
    {
        foreach (GameObject go in this.allPots)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(LaneLeftEnd.transform.position.x, 3.33f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f);
                go.SetActive(true);
                return;
            }
        }

        GameObject pot = GameObject.Instantiate(PotPrefab, new Vector3(LaneLeftEnd.transform.position.x, 3.33f - laneIndex * this.LaneHeight, this.transform.position.z + 2.0f), Quaternion.identity) as GameObject;
        pot.transform.parent = this.transform;
        this.allPots.Add(pot);
    }
}
