using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public GameObject heartImagePrefab;
    public int horizontalOffset;
    public int verticalOffset;
    public int horizontalSpace;

    public Sprite fullHeartImage;
    public Sprite emptyHeartImage;

    List<GameObject> hearts;

    void Start()
    {
        hearts = new List<GameObject>();
    }

    public void DrawHearts(int current, int max)
    {
        // add additional hearts
        if (hearts.Count < max)
        {
            GameObject heart = Instantiate(heartImagePrefab, this.transform);
            // reposition
            hearts.Add(heart);
        }
        else if (hearts.Count > max)
        {
            while (hearts.Count > max)
            {
                GameObject heart = hearts[hearts.Count - 1];
                hearts.RemoveAt(hearts.Count - 1);
                Destroy(heart.gameObject);
            }
        }

        // update images
        for (int i = 0; i < hearts.Count; i++)
        {
            // consider creating heart script to cache this
            hearts[i].GetComponent<RectTransform>().localPosition = new Vector3((i * horizontalSpace) + horizontalOffset, verticalOffset, 0);
            if (i < current)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeartImage;
            }
            else if (i >= current && i < max)
            {
                hearts[i].GetComponent<Image>().sprite = emptyHeartImage;
            }
        }
    }
}
