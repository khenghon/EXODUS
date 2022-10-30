using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Item3DViewer : MonoBehaviour,IDragHandler
{
    public ItemInteract prefab;
    private Transform itemPrefab;

    private void Start()
    {
        interact(prefab);
    }

    void interact(ItemInteract item) {
        if (itemPrefab != null) Destroy(itemPrefab.gameObject);

        itemPrefab = Instantiate(item.prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        itemPrefab.eulerAngles += new Vector3(-eventData.delta.y,-eventData.delta.x);
    }
}
