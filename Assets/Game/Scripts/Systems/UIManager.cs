using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    public GameObject player;

    public string healthID;

    public HeartDisplay heartDisplay;

    public GameObject pauseMenuScreen;

    // inventory item selection stuff
    int itemIndex = 0;
    int collectionIndex = 0;
    int lastHorizontalInput = 0;
    public IsInventoryView inventory;
    public GameObject itemHighlight;

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
                HandleUIInput();
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

    void HandleUIInput()
    {
        int horizontal = Mathf.RoundToInt(Input.GetAxis("HorizontalLeft"));

        if (horizontal != 0)
        {
            if (horizontal != lastHorizontalInput)
            {

                itemIndex += horizontal;

                if (itemIndex < 0)
                {
                    // move to previous collection
                    collectionIndex -= 1;

                    if (collectionIndex < 0)
                    {
                        // move to last collection
                        collectionIndex = inventory.collectionViews.Count - 1;
                    }

                    // this requires at least one slot
                    itemIndex = inventory.collectionViews[collectionIndex].inventorySlots.Count - 1;
                }
                else if (itemIndex >= inventory.collectionViews[collectionIndex].inventorySlots.Count)
                {
                    // move to next collection
                    collectionIndex += 1;

                    if (collectionIndex >= inventory.collectionViews.Count)
                    {
                        collectionIndex = 0;
                    }

                    itemIndex = 0;
                }

                itemHighlight.transform.SetParent(inventory.collectionViews[collectionIndex].inventorySlots[itemIndex].transform);
                itemHighlight.transform.localPosition = Vector3.zero;

                
            }
            lastHorizontalInput = horizontal;
        }
        else
        {
            lastHorizontalInput = 0;
        }

        if (Input.GetButtonDown("A"))
        {
            inventory.collectionViews[collectionIndex].inventorySlots[itemIndex].item.Select();
        }
    }
}
