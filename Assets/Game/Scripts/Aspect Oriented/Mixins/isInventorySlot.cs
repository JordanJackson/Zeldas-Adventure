using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IsInventorySlot : Mixin
{

    public string itemName;

    public IsInventoryItem item;

    public IsCollectionView owner;

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

        // create thumbnail image
    }

    public virtual void UpdateInventorySlot()
    {
        // update thumbnail image
    }

    public void OnMouseDown()
    {
        if (item)
            item.Select();
    }
}
