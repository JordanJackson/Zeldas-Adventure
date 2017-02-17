using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    public Image transitionPanel;

    public Text scoreText;
    public Text livesText;

    public Image gameOverPanel;
    public Text gameOverScoreText;

    // scene transition variables
    float time = 0.0f;
    public float transitionSpeed;
    bool transition = false;
    bool forward = true;

    public void SceneTransition()
    {
        transition = true;
    }

    void Update()
    {
        if (transition)
        {
            if (forward)
            {
                time += transitionSpeed * Time.deltaTime;
                if (time >= 1.0f)
                {
                    forward = false;
                }
            }
            else
            {
                time -= 2 * transitionSpeed * Time.deltaTime;
                if (time <= 0.0f)
                {
                    forward = true;
                    transition = false;
                }
            }
            transitionPanel.color = Color.Lerp(new Color(0.1f, 0.1f, 0.1f, 0.0f), new Color(0.1f, 0.1f, 0.1f, 1.0f), time);
        }
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLivesText(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void ShowGameOverPanel(int score)
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverScoreText.text = "Score: " + score;
        transitionPanel.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(false);
        transitionPanel.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
