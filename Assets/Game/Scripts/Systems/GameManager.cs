using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PLAYING,
        PAUSED,
        GAME_OVER
    }

    public GameState currentState;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (currentState == GameState.PLAYING)
        {
            currentState = GameState.PAUSED;
        }
        else if (currentState == GameState.PAUSED)
        {
            currentState = GameState.PLAYING;
        }
    }
}
