using UnityEngine;
using System.Collections;

public class StoryController : MonoBehaviour 
{
    private float timer = 0.0f;
    private float storyInterval = 4.0f;
    private int currentSlide = -1;

    [SerializeField]
    private MenuManager menuManager = null;
    [SerializeField]
    private GameObject[] slides = null;

    private bool inputSkip = false;

	void Start () 
    {
	
	}

    void OnEnable()
    {
        if(this.slides != null && this.slides.Length > 0)
        { 
            this.currentSlide = 0;
            this.timer = 0.0f;
            this.slides[0].SetActive(true);
        }else{
            menuManager.OnButtonMainMenu();
        }

    }

	void Update () 
    {
        this.timer += Time.deltaTime;

        if(Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if(!this.inputSkip)
            {
                this.timer -= this.storyInterval;
                if (this.timer < 0.0f) this.timer = 0.0f;
                NextSlide();
            }
            this.inputSkip = true;
        }else{
            this.inputSkip = false;
        }
        
        if(this.timer > this.storyInterval)
        {
            this.timer -= this.storyInterval;
            NextSlide();
        }
        
        
	}
    void NextSlide()
    {
        this.slides[this.currentSlide].SetActive(false);
        ++this.currentSlide;

        int slidesCount = this.slides.Length;
        if (this.currentSlide >= slidesCount)
        {
            this.menuManager.OnButtonMainMenu();
        }
        else
        {
            this.slides[this.currentSlide].SetActive(true);
        }
    }

}
