using UnityEngine;
using System.Collections;

public class Burger : MonoBehaviour {

    public Color BlinkingColor;

    private Collider2D myCollider = null;
    private SpriteRenderer myRenderer = null;
    private float timer = 0.0f;
    private bool up = true;
    private Color startColor;

    // Use this for initialization
    void Start()
    {
        myCollider = this.GetComponent<Collider2D>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        startColor = myRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        if (up)
        {
            timer += 3.5f * Time.deltaTime;
            if(timer > 1.0f)
            {
                up = false;
            }
        }
        else
        {
            timer -= 3.5f * Time.deltaTime;
            if(timer < 0.0f)
            {
                up = true;
            }
        }
        this.myRenderer.color = Color.Lerp(startColor, BlinkingColor, timer);
        if (Input.GetMouseButtonDown(0))
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
            if (hit.collider == this.myCollider)
            {
                //Collect burger
                this.gameObject.SetActive(false);
            }
        }
    }
}
