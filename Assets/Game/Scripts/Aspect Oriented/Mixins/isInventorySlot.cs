using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IsInventorySlot : Mixin
{
    public string itemName;

    public IsInventoryItem item;

    public IsCollectionView owner;


    GameObject thumbnail;
    GameObject count;

    public void Initialize(IsCollectionView owner)
    {
        this.owner = owner;
        item = owner.GetCollectionData().GetItemByName(itemName);

        if (item != null)
        {
            HasThumbnail hasThumbnail = item.GetComponent<HasThumbnail>();
            if (hasThumbnail != null)
            {
                // create thumbnail image
                thumbnail = new GameObject();
                thumbnail.transform.SetParent(this.transform);
                Image image = thumbnail.AddComponent<Image>();
                RectTransform rect = thumbnail.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(hasThumbnail.thumbHorizontalOffset, hasThumbnail.thumbVerticalOffset, 0.0f);
                rect.localScale = new Vector3(hasThumbnail.thumbScale, hasThumbnail.thumbScale, 1.0f);
                image.sprite = hasThumbnail.image;
                image.color = hasThumbnail.color;
            }
            IsCountable isCountable = item.GetComponent<IsCountable>();
            if (isCountable)
            {
                // create count object
                count = new GameObject();
                count.transform.SetParent(this.transform);
                Text text = count.AddComponent<Text>();
                count.GetComponent<RectTransform>().localPosition = new Vector3(isCountable.countHorizontalOffset, isCountable.countVerticalOffset, 0.0f);
                if (isCountable.maxAmount >= 100)
                {
                    text.text = isCountable.currentAmount.ToString("000");
                }
                else
                {
                    text.text = isCountable.currentAmount.ToString("00");
                }
                text.font = isCountable.countFont;
                text.fontSize = isCountable.countScale;
                text.alignment = TextAnchor.MiddleCenter;
            }

        }

    }

    public void UpdateInventorySlot()
    {
        if (item == null && owner != null)
        {
            if (owner.GetCollectionData() != null)
            {
                item = owner.GetCollectionData().GetItemByName(itemName);
            }
        }

        if (item != null)
        {
            // update thumbnail image
            if (thumbnail == null)
            {
                HasThumbnail hasThumbnail = item.GetComponent<HasThumbnail>();
                if (hasThumbnail != null)
                {
                    // create thumbnail image
                    thumbnail = new GameObject();
                    thumbnail.transform.SetParent(this.transform);
                    Image image = thumbnail.AddComponent<Image>();
                    RectTransform rect = thumbnail.GetComponent<RectTransform>();
                    rect.localPosition = new Vector3(hasThumbnail.thumbHorizontalOffset, hasThumbnail.thumbVerticalOffset, 0.0f);
                    rect.localScale = new Vector3(hasThumbnail.thumbScale, hasThumbnail.thumbScale, 1.0f);
                    image.sprite = hasThumbnail.image;
                    image.color = hasThumbnail.color;
                }
            }

            // update count
            if (count == null)
            {
                IsCountable isCountable = item.GetComponent<IsCountable>();
                if (isCountable)
                {
                    // create count object
                    count = new GameObject();
                    count.transform.SetParent(this.transform);
                    Text text = count.AddComponent<Text>();
                    count.GetComponent<RectTransform>().localPosition = new Vector3(isCountable.countHorizontalOffset, isCountable.countVerticalOffset, 0.0f);
                    if (isCountable.maxAmount >= 100)
                    {
                        text.text = isCountable.currentAmount.ToString("000");
                    }
                    else
                    {
                        text.text = isCountable.currentAmount.ToString("00");
                    }

                    text.font = isCountable.countFont;
                    text.fontSize = isCountable.countScale;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.color = isCountable.countColor;
                    count.AddComponent<Outline>();
                }
            }
            else
            {
                IsCountable isCountable = item.GetComponent<IsCountable>();
                if (isCountable)
                {
                    count.GetComponent<Text>().text = isCountable.currentAmount.ToString();
                }
            }
        }
    }

    public void OnMouseDown()
    {
        if (item)
            item.Select();
    }
}
