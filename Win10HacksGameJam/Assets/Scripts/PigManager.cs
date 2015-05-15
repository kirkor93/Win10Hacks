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
        if(Input.GetMouseButtonDown(0))
        {
            TryRaycast();
        }
    }

    private void TryRaycast()
    {
        RaycastHit2D hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit != null && hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Pig"))
            {
                hit.collider.gameObject.SendMessage("SmashPig");
            }
        }
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
