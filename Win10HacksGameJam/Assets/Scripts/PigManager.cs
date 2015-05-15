using UnityEngine;
using System.Collections;

public class PigManager : MonoBehaviour {

    public float InitialPigSpawnCooldown = 5.0f;
    public float SpawningCooldownDecreaseRate = 0.05f;
    public int LaneNumber = 3;

	// Use this for initialization
	void Start () 
    {
        Invoke("SpawnPig", 0.5f);
	}

    void Update()
    {

    }

    private void SpawnPig()
    {
        System.Random rnd = new System.Random();
        int lane = (int)rnd.Next() % this.LaneNumber;
        PigPool.Instance.SpawnPig(lane);
        Invoke("SpawnPig", this.InitialPigSpawnCooldown);
        this.InitialPigSpawnCooldown *= (1.0f - this.SpawningCooldownDecreaseRate);
    }
}
