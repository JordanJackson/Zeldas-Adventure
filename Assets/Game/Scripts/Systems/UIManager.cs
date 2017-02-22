using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    public GameObject player;

    public string healthID;

    public HeartDisplay heartDisplay;

    public GameObject pauseMenuScreen;


    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        if (!heartDisplay)
        {
            Debug.LogWarning("HeartDisplay GameObject not set.");
        }
    }


    void Update()
    {
        // every state
        UpdateHearts();
        switch (GameManager.Instance.currentState)
        {
            // paused
            case GameManager.GameState.PAUSED:
                DisplayInventoryUI(true);
                break;
            case GameManager.GameState.PLAYING:
                DisplayInventoryUI(false);
                break;
            default:
                break;
        }

    }

    void UpdateHearts()
    {
        int maxHealth;
        int currentHealth;

        IntData[] data = player.GetComponentsInChildren<IntData>();
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Name == healthID)
            {
                maxHealth = data[i].Max();
                currentHealth = data[i].Data();
                heartDisplay.DrawHearts(currentHealth, maxHealth);
            }
        }
    }

    void DisplayInventoryUI(bool active)
    {
        if (pauseMenuScreen != null)
        {
            pauseMenuScreen.SetActive(active);
        }
    }
}
