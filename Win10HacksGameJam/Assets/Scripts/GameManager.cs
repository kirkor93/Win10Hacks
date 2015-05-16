using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    private int cashValue = 0;
    private int burgerCashValue = 5;
    private int pigsCrashed = 0;

    [SerializeField]
    private MenuManager menuManager = null;
    [SerializeField]
    private UpgradeManager upgradeManager = null;

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
        this.cashValue = 0;
        this.pigsCrashed = 0;
        this.upgradeManager.Reset();
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
        this.menuManager.OnGameOver(this.cashValue, pigsCrashed);
        //Game over logic
    }
    public void AddBurger()
    {
        this.cashValue += burgerCashValue;
    }
    public void AddPig()
    {
        ++this.pigsCrashed;
    }

    public int GetCash()
    {
        return this.cashValue;
    }

    public void SetCash(int value)
    {
        this.cashValue = value;
    }
}
