using UnityEngine;
using System.Collections;

public class InstantPig : MonoBehaviour {
    public float Speed = 5.0f;
    public AudioClip DeathSound;
    [HideInInspector]
    public int MyLane;

    private Transform myTransform;
    private float changeLaneTimer = 0.0f;

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
        changeLaneTimer += Time.deltaTime;
        if(changeLaneTimer > 1.0f)
        {
            changeLaneTimer = 0.0f;
            if (MyLane == 4) MyLane = 3;
            else if (MyLane == 0) MyLane = 1;
            else
            {
                System.Random rnd = new System.Random();
                int r = rnd.Next() % 2;
                if (r > 0) MyLane += 1;
                else MyLane -= 1;
            }
            this.transform.position = new Vector3(this.transform.position.x, 4.3f - MyLane * 2.15f, this.transform.position.z);
        }
    }

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

    void SmashPig()
    {
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 0.4f);
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        this.gameObject.SetActive(false);
    }
}
