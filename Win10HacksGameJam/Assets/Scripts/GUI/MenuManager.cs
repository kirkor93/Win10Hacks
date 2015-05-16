using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    GS_MENUMAIN = 0,
    GS_MENUSTORY = 1,
    GS_MENUSTORY_GOTOGAME = 2,
    GS_MENUPAUSE = 3,
    GS_GAME = 4,
    GS_SCORESCREEN = 5,
    GS_MENUCREDITS = 6,
    GS_MENUUPGRADES= 7
}

public class MenuManager : MonoBehaviour 
{
    private GameState _currentGameState;
    private GameState _lastGameState;

    [SerializeField]
    private GameObject MenuMain = null;
    [SerializeField]
    private GameObject MenuStory = null;
    [SerializeField]
    private GameObject MenuPause = null;
    [SerializeField]
    private GameObject MenuGame = null;
    [SerializeField]
    private GameObject MenuScoreScreen = null;
    [SerializeField]
    private GameObject MenuCredits = null;
    [SerializeField]
    private GameObject MenuUpgrades = null;

    [SerializeField]
    private Text scoreScreenText = null;

	void Start () 
    {
        this._currentGameState = GameState.GS_MENUMAIN;
        this._lastGameState = GameState.GS_MENUMAIN;
        GameManager.Instance.Pause();
	}
	
	void Update () 
    {
	
	}

    private GameObject GetGameStateGO(GameState gs)
    {
        switch(gs)
        {
            case GameState.GS_MENUMAIN:
                return this.MenuMain;
            case GameState.GS_MENUSTORY:
                return this.MenuStory;
            case GameState.GS_MENUPAUSE:
                return this.MenuPause;
            case GameState.GS_GAME:
                return this.MenuGame;
            case GameState.GS_SCORESCREEN:
                return this.MenuScoreScreen;
            case GameState.GS_MENUCREDITS:
                return this.MenuCredits;
            case GameState.GS_MENUUPGRADES:
                return this.MenuUpgrades;
        }
        return null;
    }

    public void OnButtonNewGame()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this._currentGameState = GameState.GS_GAME;
        go = GetGameStateGO(GameState.GS_GAME);
        go.SetActive(true);
        GameManager.Instance.Unpause();
        GameManager.Instance.Reset();
    }
    public void OnButtonStory()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this._currentGameState = GameState.GS_MENUSTORY;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
    }
    public void OnButtonExit()
    {
        Application.Quit();
    }
    public void OnButtonMainMenu()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this.MenuGame.SetActive(false);
        this._currentGameState = GameState.GS_MENUMAIN;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
    }
    public void OnButtonPause()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        //go.SetActive(false);
        this._currentGameState = GameState.GS_MENUPAUSE;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
        GameManager.Instance.Pause();
    }
    public void OnButtonResume()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this._currentGameState = GameState.GS_GAME;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
        GameManager.Instance.Unpause();
    }
    public void OnGameOver(int cash, int pigs)
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this._currentGameState = GameState.GS_SCORESCREEN;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
        GameManager.Instance.Pause();
        this.scoreScreenText.text = "Game Over\nYou earned " + cash + "$ and killed " + pigs + " before they took down your favorite PigBurger...";
    }
    public void OnButtonCredits()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        go.SetActive(false);
        this._currentGameState = GameState.GS_MENUCREDITS;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
    }

    public void OnButtonUpgrades()
    {
        GameObject go = GetGameStateGO(this._currentGameState);
        //go.SetActive(false);
        this._currentGameState = GameState.GS_MENUUPGRADES;
        go = GetGameStateGO(this._currentGameState);
        go.SetActive(true);
        GameManager.Instance.Pause();
    }
}
