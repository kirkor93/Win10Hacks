using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if(instance == null)
                {
                    Debug.LogError("There is no game manager");
                }
            }
            return instance;
        }
    }

    private bool isPaused;
    public Action OnReset;

    public bool IsPaused
    {
        get
        {
            return this.isPaused;
        }
    }

    public void Reset()
    {
        if(OnReset != null)
        {
            OnReset();
        }
    }

    public void Pause()
    {
        this.isPaused = true;
    }

    public void Unpause()
    {
        this.isPaused = false;
    }

    public void GameOver()
    {
        this.isPaused = true;
        //Game over logic
    }
}
