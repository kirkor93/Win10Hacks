using UnityEngine;
using System.Collections;

public class PigManager : MonoBehaviour {

    public float InitialPigSpawnCooldown = 5.0f;
    public float SpawningCooldownDecreaseRate = 0.05f;
    public float MakeSpawningFasterCooldown = 10.0f;
    public int LaneNumber = 3;

    private float currentPigSpawnCooldown;
    private float makeItFasterTimer = 0.0f;
    private float spawnPigTimer = 0.0f;

	// Use this for initialization
	void Start () 
    {
        currentPigSpawnCooldown = InitialPigSpawnCooldown;
        GameManager.Instance.OnReset += Reset;
	}

    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        makeItFasterTimer += Time.deltaTime;
        spawnPigTimer += Time.deltaTime;
        if(spawnPigTimer > currentPigSpawnCooldown)
        {
            spawnPigTimer = 0.0f;
            SpawnPig();
        }
        if(makeItFasterTimer > MakeSpawningFasterCooldown)
        {
            makeItFasterTimer = 0.0f;
            currentPigSpawnCooldown *= (1.0f - SpawningCooldownDecreaseRate);
        }
    }

    private void SpawnPig()
    {
        System.Random rnd = new System.Random();
        int lane = (int)rnd.Next() % this.LaneNumber;
        PigPool.Instance.SpawnPig(lane);
    }

    void Reset()
    {
        currentPigSpawnCooldown = this.InitialPigSpawnCooldown;
        spawnPigTimer = 0.0f;
        makeItFasterTimer = 0.0f;
    }
}
