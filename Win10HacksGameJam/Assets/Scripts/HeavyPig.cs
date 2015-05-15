using UnityEngine;
using System.Collections;

public class HeavyPig : MonoBehaviour {

    public float Speed = 3.0f;

    private Transform myTransform;
    private int HP = 3;

    // Use this for initialization
    void Start()
    {
        this.myTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        this.myTransform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

    void SmashPig()
    {
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        --HP;
        if (HP > 0) return;
        HP = 3;
        this.gameObject.SetActive(false);
    }
}
