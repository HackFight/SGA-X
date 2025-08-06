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
}

[System.Serializable]
public struct serializableGrabbableList
{
    public List<Grabbable> list;
}