using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    private int cashValue = 0;
    private int burgerCashValue = 5;

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
        cashValue = 0;
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
    public void AddBurger()
    {
        this.cashValue += burgerCashValue;
    }

    public int GetCash()
    {
        return this.cashValue;
    }
}
