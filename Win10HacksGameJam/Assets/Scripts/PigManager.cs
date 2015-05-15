using UnityEngine;
using System.Collections;

public class PigManager : MonoBehaviour {

    public float InitialPigSpawnCooldown = 5.0f;
    public float SpawningCooldownDecreaseRate = 0.05f;
    public float MakeSpawningFasterCooldown = 10.0f;
    public int LaneNumber = 3;

	// Use this for initialization
	void Start () 
    {
        Invoke("SpawnPig", 0.5f);
        InvokeRepeating("MakeSpawningFaster", this.MakeSpawningFasterCooldown, this.MakeSpawningFasterCooldown);
	}

    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
    }

    private void SpawnPig()
    {
        System.Random rnd = new System.Random();
        int lane = (int)rnd.Next() % this.LaneNumber;
        PigPool.Instance.SpawnPig(lane);
        Invoke("SpawnPig", this.InitialPigSpawnCooldown);
    }

    private void MakeSpawningFaster()
    {
        this.InitialPigSpawnCooldown *= (1.0f - this.SpawningCooldownDecreaseRate);
    }
}
