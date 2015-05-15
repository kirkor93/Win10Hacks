using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BurgerPool : MonoBehaviour {

    private static BurgerPool instance;

    public static BurgerPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BurgerPool>();
                if (instance == null)
                {
                    Debug.LogError("There is no pig pool");
                }
            }
            return instance;
        }
    }

    public GameObject BurgerPrefab;
    public int StartBurgerCount = 5;

    private List<GameObject> allBurgers = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < this.StartBurgerCount; ++i)
        {
            GameObject go = GameObject.Instantiate(this.BurgerPrefab, this.transform.position, Quaternion.identity) as GameObject;
            go.SetActive(false);
            go.transform.parent = this.transform;
            this.allBurgers.Add(go);
        }
    }

    public void SpawnBurger(Vector3 position)
    {
        foreach (GameObject go in this.allBurgers)
        {
            if (!go.activeInHierarchy)
            {
                go.transform.position = position;
                go.SetActive(true);
                return;
            }
        }

        GameObject pot = GameObject.Instantiate(BurgerPrefab, position, Quaternion.identity) as GameObject;
        pot.transform.parent = this.transform;
        this.allBurgers.Add(pot);
    }
}
