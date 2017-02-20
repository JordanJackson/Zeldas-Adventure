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

    public int thumbHorizontalOffset;
    public int thumbVerticalOffset;
    public float thumbScale;

    public int countHorizontalOffset;
    public int countVerticalOffset;
    public int countScale;

    public Font countFont;

    GameObject thumbnail;
    GameObject count;

    public void Initialize(IsCollectionView owner)
    {
        this.owner = owner;
        item = owner.GetCollectionData().GetItemByName(itemName);
        // TODO: Mouse click system will need to be replaced by controller based item selection
        EventTrigger trigger = this.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { OnMouseDown(); });
        trigger.triggers.Add(entry);

        if (item != null)
        {
            if (item.thumbnail != null)
            {
                // create thumbnail image
                thumbnail = new GameObject();
                thumbnail.transform.SetParent(this.transform);
                Image image = thumbnail.AddComponent<Image>();
                thumbnail.GetComponent<RectTransform>().localPosition = new Vector3(thumbHorizontalOffset, thumbVerticalOffset, 0.0f);
                thumbnail.GetComponent<RectTransform>().localScale = new Vector3(thumbScale, thumbScale, 1.0f);
                image.sprite = item.thumbnail;
            }
            
            if (item.countable)
            {
                // create count object
                count = new GameObject();
                count.transform.SetParent(this.transform);
                Text text = count.AddComponent<Text>();
                count.GetComponent<RectTransform>().localPosition = new Vector3(countHorizontalOffset, countVerticalOffset, 0.0f);
                text.text = item.count.ToString();
                text.font = countFont;
                text.fontSize = countScale;
                text.alignment = TextAnchor.MiddleCenter;
            }

        }

    }

    public void UpdateInventorySlot()
    {
        // update thumbnail image

        // update count
    }

    public void OnMouseDown()
    {
        if (item)
            item.Select();
    }
}
