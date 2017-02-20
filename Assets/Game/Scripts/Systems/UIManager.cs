using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    public GameObject player;

    public string healthID;

    public HeartDisplay heartDisplay;


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
        UpdateHearts();
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
}
