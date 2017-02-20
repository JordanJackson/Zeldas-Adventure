using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{

    public int score = 0;
    public int lives = 3;

    bool gameOver = false;

    void Start()
    {
        // play intro?
        // set up first level
    }

    void Update()
    {
        if (lives <= 0)
        {
            // gameover
            gameOver = true;
            // show UI

        }
        if (gameOver)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                gameOver = false;
                // hide UI

                score = 0;
                lives = 3;
                LevelManager.Instance.SetNextLevel("Level1");
            }
        }
    }

    public void UpdateScore(int delta)
    {
        score += delta;

        
    }

    public void UpdateLives(int delta)
    {
        lives += delta;
    }
}
