using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<serializableGrabbableList> itemLists = new List<serializableGrabbableList>();

    public void ReloadList(int i)
    {
        for (int j = 0; j < itemLists[i].list.Count; j++)
        {
            itemLists[i].list[j].Init();
        }
    }

    public void ReloadAll()
    {
        foreach (serializableGrabbableList itemList in itemLists)
        {
            foreach (Grabbable item in itemList.list)
            {
                item.Init();
            }
        }
    }
}

[System.Serializable]
public struct serializableGrabbableList
{
    public List<Grabbable> list;
}