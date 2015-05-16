using UnityEngine;
using System.Collections;

public class HeavyPig : MonoBehaviour {

    public float Speed = 3.0f;
    public AudioClip DeathSound;

    private Transform myTransform;
    private int HP = 3;
    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        this.myTransform = this.GetComponent<Transform>();
        this.myAnimator = this.GetComponent<Animator>();
        this.myAnimator.SetFloat("sth", (float)this.HP / 3.0f);
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
        --HP;
        this.myAnimator.SetFloat("sth", (float)this.HP / 3.0f);
        if (HP > 0) return;
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 0.4f);
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        this.gameObject.SetActive(false);
    }

    public void OnSpawn()
    {
        HP = 3;
        this.myAnimator = this.GetComponent<Animator>();
        this.myAnimator.SetFloat("sth", 1.0f);
    }
}
