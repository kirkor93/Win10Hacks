using UnityEngine;
using System.Collections;

public class PigManager : MonoBehaviour {

    public float InitialPigSpawnCooldown = 5.0f;
    public float SpawningCooldownDecreaseRate = 0.05f;
    public float MakeSpawningFasterCooldown = 10.0f;
    public int LaneNumber = 3;

    private float currentPigSpawnCooldown;

	// Use this for initialization
	void Start () 
    {
        currentPigSpawnCooldown = InitialPigSpawnCooldown;
        Invoke("SpawnPig", 0.5f);
        InvokeRepeating("MakeSpawningFaster", this.MakeSpawningFasterCooldown, this.MakeSpawningFasterCooldown);
        GameManager.Instance.OnReset += Reset;
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
        Invoke("SpawnPig", this.currentPigSpawnCooldown);
    }

    private void MakeSpawningFaster()
    {
        this.currentPigSpawnCooldown *= (1.0f - this.SpawningCooldownDecreaseRate);
    }

    void Reset()
    {
        CancelInvoke("MakeSpawningFaster");
        CancelInvoke("SpawnPig");
        currentPigSpawnCooldown = this.InitialPigSpawnCooldown;
        Invoke("SpawnPig", 0.5f);
        InvokeRepeating("MakeSpawningFaster", this.MakeSpawningFasterCooldown, this.MakeSpawningFasterCooldown);
    }
}
