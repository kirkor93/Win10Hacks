using UnityEngine;
using System.Collections;

public class InstantPig : MonoBehaviour {
    public float Speed = 5.0f;
    public float ChangeLaneSpeed = 3.0f;
    public AudioClip DeathSound;
    public ParticleSystem TopFlame;
    public ParticleSystem BottomFlame;
    [HideInInspector]
    public int MyLane;

    private Transform myTransform;
    private float changeLaneTimer = 0.0f;
    private float lerpTimer = 0.0f;
    private Vector3 newPosition;
    private Vector3 oldPosition;

    // Use this for initialization
    void Start()
    {
        this.myTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        //this.myTransform.Translate(Vector3.left * Speed * Time.deltaTime);
        oldPosition += Vector3.left * Speed * Time.deltaTime;
        newPosition += Vector3.left * Speed * Time.deltaTime;
        changeLaneTimer += Time.deltaTime;
        if(changeLaneTimer > 2.0f)
        {
            changeLaneTimer = 0.0f;
            lerpTimer = 0.0f;
            if (MyLane == 4)
            {
                BottomFlame.Emit(10);
                MyLane = 3;
            }
            else if (MyLane == 0)
            {
                MyLane = 1;
                TopFlame.Emit(10);
            }
            else
            {
                System.Random rnd = new System.Random();
                int r = rnd.Next() % 2;
                if (r > 0)
                {
                    TopFlame.Emit(10);
                    MyLane += 1;
                }
                else
                {
                    BottomFlame.Emit(10);
                    MyLane -= 1;
                }
            }
            oldPosition = this.transform.position;
            newPosition = new Vector3(this.transform.position.x, 4.3f - MyLane * 2.15f, this.transform.position.z);
        }
        lerpTimer += ChangeLaneSpeed * Time.deltaTime;
        lerpTimer = Mathf.Clamp01(lerpTimer);
        this.transform.position = Vector3.Lerp(oldPosition, newPosition, lerpTimer);
    }

    public void OnSpawn()
    {
        oldPosition = this.transform.position;
        newPosition = this.transform.position;
    }

    void Kill()
    {
        this.gameObject.SetActive(false);
    }

    void SmashPig()
    {
        GameManager.Instance.AddPig();
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 0.10f);
        BurgerPool.Instance.SpawnBurger(this.myTransform.position);
        this.gameObject.SetActive(false);
    }
}
